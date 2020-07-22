using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICertRepository
    {
        List<CertModel> GetAll();

        int AddManyCerts(List<BlankCertModel> blankCertModels, List<StudentModel> simpleStudentViewModels, string certName);

        List<CertModel> GetAllNotPrintedCert();

        CertModel GetSingleCertById(int certId);

        int DeleteCert(int certId);

        List<CertModel> GetAllNotPrintedCertBySchool(int schoolId);

        List<CertModel> SearchCert(string studentName, int schoolId, string serial, string referenceNumber);
    }
    public class CertRepository : ICertRepository
    {
        SqlConnection conn;

        public int AddManyCerts(List<BlankCertModel> blankCertModels, List<StudentModel> studentModels, string certName)
        {
            int rowEffected = 0;
            using(conn = JBCertConnection.Instance)
            {
                string queryString = "AddCert_Proc";
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                SqlCommand sqlCommand = null;
                try
                {
                    for(int i = 0; i < blankCertModels.Count; i++)
                    {
                        sqlCommand = new SqlCommand(queryString, conn, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@HocsinhID", studentModels[i].Id);
                        sqlCommand.Parameters.AddWithValue("@XeploaiId", studentModels[i].RankingId);
                        sqlCommand.Parameters.AddWithValue("@Tenbang", certName);
                        sqlCommand.Parameters.AddWithValue("@PhoiId", blankCertModels[i].Id);
                        sqlCommand.Parameters.AddWithValue("@Sovaoso", blankCertModels[i].ReferenceNumber);
                        rowEffected += sqlCommand.ExecuteNonQuery();
                    }
                    sqlTransaction.Commit();
                }
                catch(Exception ex)
                {
                    sqlTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

            return rowEffected;
        }

        public int DeleteCert(int certId)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"update [dbo].[tblBang]
                                        set IsDeleted = 1
                                        Where Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", certId);
                try
                {
                    int rowEffected = sqlCommand.ExecuteNonQuery();
                    return rowEffected;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        public List<CertModel> GetAll()
        {
            List<CertModel> certModels = new List<CertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Ten as 'Hovaten', b.TruongId , f.Tentruong ,c.Tenxeploai, d.Serial as 'Sohieu', d.LoaiId, e.Name as 'Tenloai' 
                                      FROM [dbo].[tblBang] as a
                                      left join [dbo].[tblHocsinh] as b
                                      on a.HocsinhId = b.Id
                                      Left join [dbo].[tblXeploai] as c
                                      on a.XeploaiId = c.Id
                                      left join [dbo].[tblPhoi] as d
                                      on a.PhoiId = d.Id
                                      left join [dbo].[tblLoai] as e
                                      on d.LoaiId = e.Id
									  left join [dbo].[tblTruong] as f
									  on b.TruongId = f.Id
                                      where a.isdeleted = 0";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        CertModel certModel = new CertModel();
                        certModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        certModel.StudentId = int.Parse(sqlDataReader["HocsinhId"].ToString());
                        certModel.StudentName = sqlDataReader["Hovaten"].ToString();
                        certModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        certModel.RankingName = sqlDataReader["Tenxeploai"].ToString();
                        certModel.CertName = sqlDataReader["Tenbang"].ToString();
                        certModel.BlankCertId = int.Parse(sqlDataReader["PhoiId"].ToString());
                        certModel.Serial = sqlDataReader["Sohieu"].ToString();
                        certModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        certModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        certModel.ReferenceNumber = sqlDataReader["Sovaoso"].ToString();
                        certModel.ProviderName = sqlDataReader["Tennguoicap"].ToString();
                        certModel.Position = sqlDataReader["Chucvu"].ToString();
                        certModel.GrantedDate = DateTime.Parse(sqlDataReader["Ngaycap"].ToString());
                        certModel.ManagementAddress = sqlDataReader["Noiquanly"].ToString();
                        certModel.ReceiverName = sqlDataReader["Nguoinhan"].ToString();
                        certModel.ReceiverIdentityNumber = sqlDataReader["CMTnguoinhan"].ToString();
                        certModel.Note = sqlDataReader["Ghichu"].ToString();
                        certModel.IsGranted = bool.Parse(sqlDataReader["IsGranted"].ToString());
                        certModel.IsPrinted = bool.Parse(sqlDataReader["IsPrinted"].ToString());
                        certModel.IsDeleted = false;

                        certModels.Add(certModel);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return certModels;
        }

        public List<CertModel> GetAllNotPrintedCert()
        {
            List<CertModel> certModels = new List<CertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Ten as 'Hovaten', b.TruongId , f.Tentruong ,c.Tenxeploai, d.Serial as 'Sohieu', d.LoaiId, e.Name as 'Tenloai' 
                                      FROM [dbo].[tblBang] as a
                                      left join [dbo].[tblHocsinh] as b
                                      on a.HocsinhId = b.Id
                                      Left join [dbo].[tblXeploai] as c
                                      on a.XeploaiId = c.Id
                                      left join [dbo].[tblPhoi] as d
                                      on a.PhoiId = d.Id
                                      left join [dbo].[tblLoai] as e
                                      on d.LoaiId = e.Id
									  left join [dbo].[tblTruong] as f
									  on b.TruongId = f.Id
                                      where a.isdeleted = 0 and a.IsPrinted = 0";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        CertModel certModel = new CertModel();
                        certModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        certModel.StudentId = int.Parse(sqlDataReader["HocsinhId"].ToString());
                        certModel.StudentName = sqlDataReader["Hovaten"].ToString();
                        certModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        certModel.RankingName = sqlDataReader["Tenxeploai"].ToString();
                        certModel.CertName = sqlDataReader["Tenbang"].ToString();
                        certModel.BlankCertId = int.Parse(sqlDataReader["PhoiId"].ToString());
                        certModel.Serial = sqlDataReader["Sohieu"].ToString();
                        certModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        certModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        certModel.ReferenceNumber = sqlDataReader["Sovaoso"].ToString();
                        certModel.ProviderName = sqlDataReader["Tennguoicap"].ToString();
                        certModel.Position = sqlDataReader["Chucvu"].ToString();
                        certModel.GrantedDate = DateTime.Parse(sqlDataReader["Ngaycap"].ToString());
                        certModel.ManagementAddress = sqlDataReader["Noiquanly"].ToString();
                        certModel.ReceiverName = sqlDataReader["Nguoinhan"].ToString();
                        certModel.ReceiverIdentityNumber = sqlDataReader["CMTnguoinhan"].ToString();
                        certModel.Note = sqlDataReader["Ghichu"].ToString();
                        certModel.IsGranted = bool.Parse(sqlDataReader["IsGranted"].ToString());
                        certModel.IsPrinted = bool.Parse(sqlDataReader["IsPrinted"].ToString());
                        certModel.IsDeleted = false;

                        certModels.Add(certModel);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return certModels;
        }

        public List<CertModel> GetAllNotPrintedCertBySchool(int schoolId)
        {
            List<CertModel> certModels = new List<CertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Ten as 'Hovaten', b.TruongId , f.Tentruong ,c.Tenxeploai, d.Serial as 'Sohieu', d.LoaiId, e.Name as 'Tenloai' 
                                      FROM [dbo].[tblBang] as a
                                      left join [dbo].[tblHocsinh] as b
                                      on a.HocsinhId = b.Id
                                      Left join [dbo].[tblXeploai] as c
                                      on a.XeploaiId = c.Id
                                      left join [dbo].[tblPhoi] as d
                                      on a.PhoiId = d.Id
                                      left join [dbo].[tblLoai] as e
                                      on d.LoaiId = e.Id
									  left join [dbo].[tblTruong] as f
									  on b.TruongId = f.Id
                                      where a.isdeleted = 0 and a.IsPrinted = 0 and b.TruongId = @TruongId";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@TruongId", schoolId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        CertModel certModel = new CertModel();
                        certModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        certModel.StudentId = int.Parse(sqlDataReader["HocsinhId"].ToString());
                        certModel.StudentName = sqlDataReader["Hovaten"].ToString();
                        certModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        certModel.RankingName = sqlDataReader["Tenxeploai"].ToString();
                        certModel.CertName = sqlDataReader["Tenbang"].ToString();
                        certModel.BlankCertId = int.Parse(sqlDataReader["PhoiId"].ToString());
                        certModel.Serial = sqlDataReader["Sohieu"].ToString();
                        certModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        certModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        certModel.ReferenceNumber = sqlDataReader["Sovaoso"].ToString();
                        certModel.ProviderName = sqlDataReader["Tennguoicap"].ToString();
                        certModel.Position = sqlDataReader["Chucvu"].ToString();
                        certModel.GrantedDate = DateTime.Parse(sqlDataReader["Ngaycap"].ToString());
                        certModel.ManagementAddress = sqlDataReader["Noiquanly"].ToString();
                        certModel.ReceiverName = sqlDataReader["Nguoinhan"].ToString();
                        certModel.ReceiverIdentityNumber = sqlDataReader["CMTnguoinhan"].ToString();
                        certModel.Note = sqlDataReader["Ghichu"].ToString();
                        certModel.IsGranted = bool.Parse(sqlDataReader["IsGranted"].ToString());
                        certModel.IsPrinted = bool.Parse(sqlDataReader["IsPrinted"].ToString());
                        certModel.IsDeleted = false;

                        certModels.Add(certModel);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return certModels;
        }

        public CertModel GetSingleCertById(int certId)
        {
            CertModel certModel = new CertModel();

            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Ten as 'Hovaten', b.TruongId , f.Tentruong ,c.Tenxeploai, d.Serial as 'Sohieu', d.LoaiId, e.Name as 'Tenloai' 
                                      FROM [dbo].[tblBang] as a
                                      left join [dbo].[tblHocsinh] as b
                                      on a.HocsinhId = b.Id
                                      Left join [dbo].[tblXeploai] as c
                                      on a.XeploaiId = c.Id
                                      left join [dbo].[tblPhoi] as d
                                      on a.PhoiId = d.Id
                                      left join [dbo].[tblLoai] as e
                                      on d.LoaiId = e.Id
									  left join [dbo].[tblTruong] as f
									  on b.TruongId = f.Id
                                      where a.Id = @Id";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", certId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        certModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        certModel.StudentId = int.Parse(sqlDataReader["HocsinhId"].ToString());
                        certModel.StudentName = sqlDataReader["Hovaten"].ToString();
                        certModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        certModel.RankingName = sqlDataReader["Tenxeploai"].ToString();
                        certModel.CertName = sqlDataReader["Tenbang"].ToString();
                        certModel.BlankCertId = int.Parse(sqlDataReader["PhoiId"].ToString());
                        certModel.Serial = sqlDataReader["Sohieu"].ToString();
                        certModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        certModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        certModel.ReferenceNumber = sqlDataReader["Sovaoso"].ToString();
                        certModel.ProviderName = sqlDataReader["Tennguoicap"].ToString();
                        certModel.Position = sqlDataReader["Chucvu"].ToString();
                        certModel.GrantedDate = DateTime.Parse(sqlDataReader["Ngaycap"].ToString());
                        certModel.ManagementAddress = sqlDataReader["Noiquanly"].ToString();
                        certModel.ReceiverName = sqlDataReader["Nguoinhan"].ToString();
                        certModel.ReceiverIdentityNumber = sqlDataReader["CMTnguoinhan"].ToString();
                        certModel.Note = sqlDataReader["Ghichu"].ToString();
                        certModel.IsGranted = bool.Parse(sqlDataReader["IsGranted"].ToString());
                        certModel.IsPrinted = bool.Parse(sqlDataReader["IsPrinted"].ToString());
                        certModel.IsDeleted = false;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return certModel;
        }

        public List<CertModel> SearchCert(string studentName, int schoolId, string serial, string referenceNumber)
        {
            List<CertModel> certModels = new List<CertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Ten as 'Hovaten', b.TruongId , f.Tentruong ,c.Tenxeploai, d.Serial as 'Sohieu', d.LoaiId, e.Name as 'Tenloai' 
                                      FROM [dbo].[tblBang] as a
                                      left join [dbo].[tblHocsinh] as b
                                      on a.HocsinhId = b.Id
                                      Left join [dbo].[tblXeploai] as c
                                      on a.XeploaiId = c.Id
                                      left join [dbo].[tblPhoi] as d
                                      on a.PhoiId = d.Id
                                      left join [dbo].[tblLoai] as e
                                      on d.LoaiId = e.Id
									  left join [dbo].[tblTruong] as f
									  on b.TruongId = f.Id
                                      where a.isdeleted = 0
                                        and b.Ten Like @Hovaten
                                        and d.Serial Like @Sohieu
                                        and Sovaoso Like @Sovaoso
                                        and (@TruongId = -1 or TruongId = @TruongId)";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Hovaten", "%" + studentName + "%");
                sqlCommand.Parameters.AddWithValue("@Sohieu", "%" + serial + "%");
                sqlCommand.Parameters.AddWithValue("@Sovaoso", "%" + referenceNumber + "%");
                sqlCommand.Parameters.AddWithValue("@TruongId", schoolId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        CertModel certModel = new CertModel();
                        certModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        certModel.StudentId = int.Parse(sqlDataReader["HocsinhId"].ToString());
                        certModel.StudentName = sqlDataReader["Hovaten"].ToString();
                        certModel.RankingId = int.Parse(sqlDataReader["XeploaiId"].ToString());
                        certModel.RankingName = sqlDataReader["Tenxeploai"].ToString();
                        certModel.CertName = sqlDataReader["Tenbang"].ToString();
                        certModel.BlankCertId = int.Parse(sqlDataReader["PhoiId"].ToString());
                        certModel.Serial = sqlDataReader["Sohieu"].ToString();
                        certModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        certModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        certModel.ReferenceNumber = sqlDataReader["Sovaoso"].ToString();
                        certModel.ProviderName = sqlDataReader["Tennguoicap"].ToString();
                        certModel.Position = sqlDataReader["Chucvu"].ToString();
                        certModel.GrantedDate = DateTime.Parse(sqlDataReader["Ngaycap"].ToString());
                        certModel.ManagementAddress = sqlDataReader["Noiquanly"].ToString();
                        certModel.ReceiverName = sqlDataReader["Nguoinhan"].ToString();
                        certModel.ReceiverIdentityNumber = sqlDataReader["CMTnguoinhan"].ToString();
                        certModel.Note = sqlDataReader["Ghichu"].ToString();
                        certModel.IsGranted = bool.Parse(sqlDataReader["IsGranted"].ToString());
                        certModel.IsPrinted = bool.Parse(sqlDataReader["IsPrinted"].ToString());
                        certModel.IsDeleted = false;

                        certModels.Add(certModel);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlDataReader.Close();
                    conn.Close();
                }
            }

            return certModels;
        }
    }
}
