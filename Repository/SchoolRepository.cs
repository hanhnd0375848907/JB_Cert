using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISchoolRepository
    {
        List<SchoolModel> GetAll();

        int AddSchool(SchoolModel schoolModel);

        int UpdateSchool(SchoolModel schoolModel);

        SchoolModel GetSingleSchoolById(int schoolId);

        int DeleteSchool(int schoolId);

        List<SchoolModel> GetAllSchoolByBlankCertTypeId(int blankCertTypeId);

        List<SchoolModel> SearchSchool(string schoolName, int townId, int villageId, string phoneNumber);

    }
    public class SchoolRepository : ISchoolRepository
    {
        SqlConnection conn;    

        public int AddSchool(SchoolModel schoolModel)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblTruong]
                                           ([XaId],[Tentruong],[Nguoidaidien] ,[Tinh] ,[Diachi] ,[Dienthoai] ,[Fax],[Ghichu] ,[Hedaotao] ,[LoaiId] ,[IsDeleted])
                                     VALUES
                                           (@XaId, @Tentruong, @Nguoidaidien, @Tinh, @Diachi, @Dienthoai, @Fax, @Ghichu, '', @LoaiId, 0)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@XaId", schoolModel.VillageId);
                sqlCommand.Parameters.AddWithValue("@Tentruong", schoolModel.SchoolName);
                sqlCommand.Parameters.AddWithValue("@Nguoidaidien", schoolModel.Representative);
                sqlCommand.Parameters.AddWithValue("@Tinh", schoolModel.Province);
                sqlCommand.Parameters.AddWithValue("@Diachi", schoolModel.Address);
                sqlCommand.Parameters.AddWithValue("@Dienthoai", schoolModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Fax", schoolModel.Fax);
                sqlCommand.Parameters.AddWithValue("@Ghichu", schoolModel.Note);
                sqlCommand.Parameters.AddWithValue("@LoaiId", schoolModel.BlankCertTypeId);
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

        public int DeleteSchool(int schoolId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblTruong]
                                       SET [IsDeleted] = 1
                                     WHERE [Id] = @Id";

                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", schoolId);
                try
                {
                    int rowEffected = sqlCommand.ExecuteNonQuery();
                    return rowEffected;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        public List<SchoolModel> GetAll()
        {
            List<SchoolModel> schoolModels = new List<SchoolModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*,b.HuyenId, b.Ten as 'Tenxa', c.Ten as 'Tenhuyen', d.Name 'Tenloai' FROM [dbo].[tblTruong] as a
                                        left join [dbo].[tblXa] as b on a.XaId = b.Id
                                        left join [dbo].[tblHuyen] as c on b.HuyenId = c.Id
                                        left join [dbo].[tblLoai] as d on a.LoaiId = d.Id
                                        where a.IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        SchoolModel schoolModel = new SchoolModel();
                        schoolModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        schoolModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        schoolModel.VillageId = int.Parse(sqlDataReader["XaId"].ToString());
                        schoolModel.VillageName = sqlDataReader["Tenxa"].ToString();
                        schoolModel.Representative = sqlDataReader["Nguoidaidien"].ToString();
                        schoolModel.Province = sqlDataReader["Tinh"].ToString();
                        schoolModel.TownId = int.Parse(sqlDataReader["HuyenId"].ToString());
                        schoolModel.TownName = sqlDataReader["Tenhuyen"].ToString();
                        schoolModel.Address = sqlDataReader["Diachi"].ToString();
                        schoolModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        schoolModel.Fax = sqlDataReader["Fax"].ToString();
                        schoolModel.Note = sqlDataReader["Ghichu"].ToString();
                        schoolModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        schoolModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();

                        schoolModels.Add(schoolModel);
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

            return schoolModels;
        }

        public List<SchoolModel> GetAllSchoolByBlankCertTypeId(int blankCertTypeId)
        {
            List<SchoolModel> schoolModels = new List<SchoolModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*,b.HuyenId, b.Ten as 'Tenxa', c.Ten as 'Tenhuyen', d.Name 'Tenloai' FROM [dbo].[tblTruong] as a
                                        left join [dbo].[tblXa] as b on a.XaId = b.Id
                                        left join [dbo].[tblHuyen] as c on b.HuyenId = c.Id
                                        left join [dbo].[tblLoai] as d on a.LoaiId = d.Id
                                        where a.IsDeleted = 0 and a.LoaiId = @LoaiId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@LoaiId", blankCertTypeId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        SchoolModel schoolModel = new SchoolModel();
                        schoolModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        schoolModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        schoolModel.VillageId = int.Parse(sqlDataReader["XaId"].ToString());
                        schoolModel.VillageName = sqlDataReader["Tenxa"].ToString();
                        schoolModel.Representative = sqlDataReader["Nguoidaidien"].ToString();
                        schoolModel.Province = sqlDataReader["Tinh"].ToString();
                        schoolModel.TownId = int.Parse(sqlDataReader["HuyenId"].ToString());
                        schoolModel.TownName = sqlDataReader["Tenhuyen"].ToString();
                        schoolModel.Address = sqlDataReader["Diachi"].ToString();
                        schoolModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        schoolModel.Fax = sqlDataReader["Fax"].ToString();
                        schoolModel.Note = sqlDataReader["Ghichu"].ToString();
                        schoolModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        schoolModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();

                        schoolModels.Add(schoolModel);
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

            return schoolModels;
        }

        public SchoolModel GetSingleSchoolById(int schoolId)
        {
            SchoolModel schoolModel = new SchoolModel();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*,b.HuyenId, b.Ten as 'Tenxa', c.Ten as 'Tenhuyen', d.Name 'Tenloai' FROM [dbo].[tblTruong] as a
                                        left join [dbo].[tblXa] as b on a.XaId = b.Id
                                        left join [dbo].[tblHuyen] as c on b.HuyenId = c.Id
                                        left join [dbo].[tblLoai] as d on a.LoaiId = d.Id
                                        where a.[Id] = @Id";

                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", schoolId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        schoolModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        schoolModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        schoolModel.VillageId = int.Parse(sqlDataReader["XaId"].ToString());
                        schoolModel.VillageName = sqlDataReader["Tenxa"].ToString();
                        schoolModel.Province = sqlDataReader["Tinh"].ToString();
                        schoolModel.Representative = sqlDataReader["Nguoidaidien"].ToString();
                        schoolModel.TownId = int.Parse(sqlDataReader["HuyenId"].ToString());
                        schoolModel.TownName = sqlDataReader["Tenhuyen"].ToString();
                        schoolModel.Address = sqlDataReader["Diachi"].ToString();
                        schoolModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        schoolModel.Fax = sqlDataReader["Fax"].ToString();
                        schoolModel.Note = sqlDataReader["Ghichu"].ToString();
                        schoolModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        schoolModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
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

            return schoolModel;
        }

        public List<SchoolModel> SearchSchool(string schoolName, int townId, int villageId, string phoneNumber)
        {
            List<SchoolModel> schoolModels = new List<SchoolModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*,b.HuyenId, b.Ten as 'Tenxa', c.Ten as 'Tenhuyen', d.Name 'Tenloai' FROM [dbo].[tblTruong] as a
                                        left join [dbo].[tblXa] as b on a.XaId = b.Id
                                        left join [dbo].[tblHuyen] as c on b.HuyenId = c.Id
                                        left join [dbo].[tblLoai] as d on a.LoaiId = d.Id
                                        where a.IsDeleted = 0
                                            and a.Tentruong like @Tentruong
                                            and (@XaId = -1 or a.XaId = @Xaid)
                                            and (@HuyenId = -1 or b.Id = @HuyenId)
                                            and a.Dienthoai like @Dienthoai";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Tentruong", "%" + schoolName + "%");
                sqlCommand.Parameters.AddWithValue("@XaId", townId);
                sqlCommand.Parameters.AddWithValue("@HuyenId", villageId);
                sqlCommand.Parameters.AddWithValue("@Dienthoai", "%" + phoneNumber + "%");
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        SchoolModel schoolModel = new SchoolModel();
                        schoolModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        schoolModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        schoolModel.VillageId = int.Parse(sqlDataReader["XaId"].ToString());
                        schoolModel.VillageName = sqlDataReader["Tenxa"].ToString();
                        schoolModel.Representative = sqlDataReader["Nguoidaidien"].ToString();
                        schoolModel.Province = sqlDataReader["Tinh"].ToString();
                        schoolModel.TownId = int.Parse(sqlDataReader["HuyenId"].ToString());
                        schoolModel.TownName = sqlDataReader["Tenhuyen"].ToString();
                        schoolModel.Address = sqlDataReader["Diachi"].ToString();
                        schoolModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        schoolModel.Fax = sqlDataReader["Fax"].ToString();
                        schoolModel.Note = sqlDataReader["Ghichu"].ToString();
                        schoolModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        schoolModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();

                        schoolModels.Add(schoolModel);
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

            return schoolModels;
        }

        public int UpdateSchool(SchoolModel schoolModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblTruong]
                                       SET [XaId] = @XaId
                                          ,[Tentruong] = @Tentruong
                                          ,[Nguoidaidien] = @Nguoidaidien
                                          ,[Tinh] = @Tinh
                                          ,[Diachi] = @Diachi
                                          ,[Dienthoai] = @Dienthoai
                                          ,[Fax] = @Fax
                                          ,[Ghichu] = @Ghichu
                                          ,[LoaiId] = @LoaiId
                                     WHERE [Id] = @Id";

                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", schoolModel.Id);
                sqlCommand.Parameters.AddWithValue("@XaId", schoolModel.VillageId);
                sqlCommand.Parameters.AddWithValue("@Tentruong", schoolModel.SchoolName);
                sqlCommand.Parameters.AddWithValue("@Nguoidaidien", schoolModel.Representative);
                sqlCommand.Parameters.AddWithValue("@Tinh", schoolModel.Province);
                sqlCommand.Parameters.AddWithValue("@Diachi", schoolModel.Address);
                sqlCommand.Parameters.AddWithValue("@Dienthoai", schoolModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Fax", schoolModel.Fax);
                sqlCommand.Parameters.AddWithValue("@Ghichu", schoolModel.Note);
                sqlCommand.Parameters.AddWithValue("@LoaiId", schoolModel.BlankCertTypeId);

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
    }
}
