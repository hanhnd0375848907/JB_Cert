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
    public interface IBlankCertRepository
    {
        List<BlankCertModel> GetAll();

        BlankCertModel GetSingleById(int certId);

        string GetBlankCertImage(int blankCertId);

        List<BlankCertModel> GetAllAvailableBlankCert();

        List<BlankCertModel> SearchAvailableBlankCertBySerial(string serial);

        List<BlankCertModel> SearchAvailableBlankCertBySerialAndBlankCertType(string serial, int blankCertTypeId);

        int Update(BlankCertModel blankCertModel);

        int Delete(int certId);

        int Add(string serial, string createdById, string image, int blankCertTypeId);

        List<BlankCertModel> SearchBlankCertFormForAddingCert(string serial, int blankCertTypeId);

        List<BlankCertModel> SearchBlankCert(string serial, int blankCertTypeId, int status);
    }
    public class BlankCertRepository : IBlankCertRepository
    {
        private SqlConnection conn;
        public BlankCertRepository()
        {
        }

        public int Add(string serial, string createdById, string image,int blankCertTypeId)
        {
            using (conn = JBCertConnection.Instance)
            {
                try
                {
                    string queryString = @"INSERT INTO [dbo].[tblPhoi]
                                       ([Serial],[IsAvailable],[CreatedAt],[UpdatedAt],[IsReturned] ,[ReasonReturn] ,[IsDeleted],[ReferenceNumber],[Image],[LoaiId])
                                         VALUES(@Serial, @IsAvailable, @CreatedAt, @UpdatedAt, @IsReturned, @ReasonReturn, @IsDeleted, @ReferenceNumber, @Image, @BlankCertTypeId)
                                    ";
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@Serial", serial);
                    sqlCommand.Parameters.AddWithValue("@IsAvailable", true);
                    sqlCommand.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@IsReturned", false);
                    sqlCommand.Parameters.AddWithValue("@ReasonReturn", "");
                    sqlCommand.Parameters.AddWithValue("@IsDeleted", false);
                    sqlCommand.Parameters.AddWithValue("@ReferenceNumber", "");
                    sqlCommand.Parameters.AddWithValue("@Image", image);
                    sqlCommand.Parameters.AddWithValue("@BlankCertTypeId", blankCertTypeId);


                    int rowAffected = sqlCommand.ExecuteNonQuery();
                    return rowAffected;
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

        public int Delete(int certId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string stringQuery = @"Update [dbo].[tblPhoi]
                                        Set [IsDeleted] = 1 Where [Id] = @Id";
                try
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand(stringQuery, conn);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@Id", certId);
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

        public List<BlankCertModel> GetAll()
        {
            List<BlankCertModel> blankCertModels = new List<BlankCertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Select a.*, b.Name as 'Tenloai' From [dbo].[tblPhoi] as a Left Join [dbo].[tblLoai] as b
                                        On a.[LoaiId] = b.[Id] 
                                        Where a.[IsDeleted] = 0";
                SqlCommand command = new SqlCommand(queryString, conn);
                conn.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        BlankCertModel blankCertModel = new BlankCertModel();
                        blankCertModel.Id = int.Parse(sqlDataReader["id"].ToString());
                        blankCertModel.Serial = sqlDataReader["Serial"].ToString();
                        blankCertModel.IsAvailable = bool.Parse(sqlDataReader["IsAvailable"].ToString());
                        blankCertModel.CreatedAt = DateTime.Parse(sqlDataReader["CreatedAt"].ToString());
                        blankCertModel.UpdatedAt = DateTime.Parse(sqlDataReader["UpdatedAt"].ToString());
                        blankCertModel.IsReturned = bool.Parse(sqlDataReader["IsReturned"].ToString());
                        blankCertModel.ReasonReturn = sqlDataReader["ReasonReturn"].ToString();
                        blankCertModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());
                        blankCertModel.ReferenceNumber = sqlDataReader["ReferenceNumber"].ToString();
                        blankCertModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        blankCertModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();

                        blankCertModels.Add(blankCertModel);
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

            return blankCertModels;
        }

        public List<BlankCertModel> GetAllAvailableBlankCert()
        {
            List<BlankCertModel> blankCertModels = new List<BlankCertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Select * From [dbo].[TblPhoi] where [dbo].[TblPhoi].[IsDeleted] = 0 and [dbo].[TblPhoi].[IsAvailable] = 1";
                SqlCommand command = new SqlCommand(queryString, conn);
                conn.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        BlankCertModel blankCertModel = new BlankCertModel();
                        blankCertModel.Id = int.Parse(sqlDataReader["id"].ToString());
                        blankCertModel.Serial = sqlDataReader["Serial"].ToString();
                        blankCertModel.IsAvailable = bool.Parse(sqlDataReader["IsAvailable"].ToString());
                        blankCertModel.CreatedAt = DateTime.Parse(sqlDataReader["CreatedAt"].ToString());
                        blankCertModel.UpdatedAt = DateTime.Parse(sqlDataReader["UpdatedAt"].ToString());
                        blankCertModel.IsReturned = bool.Parse(sqlDataReader["IsReturned"].ToString());
                        blankCertModel.ReasonReturn = sqlDataReader["ReasonReturn"].ToString();
                        blankCertModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());
                        blankCertModel.ReferenceNumber = sqlDataReader["ReferenceNumber"].ToString();

                        blankCertModels.Add(blankCertModel);
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

            return blankCertModels;
        }

        public string GetBlankCertImage(int blankCertId)
        {
            string image = "";
            using (conn = JBCertConnection.Instance)
            {

                string sqlQuery = "Select Image From [dbo].[tblPhoi] where [Id] = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", blankCertId);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        image = sqlDataReader["Image"].ToString();
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

            return image;
        }

        public BlankCertModel GetSingleById(int certId)
        {
            BlankCertModel blankCertModel = null;
            using (conn = JBCertConnection.Instance)
            {

                string sqlQuery = "Select * From [dbo].[tblPhoi] where [Id] = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", certId);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        blankCertModel = new BlankCertModel();
                        blankCertModel.Id = int.Parse(sqlDataReader["id"].ToString());
                        blankCertModel.Serial = sqlDataReader["Serial"].ToString();
                        blankCertModel.Image = sqlDataReader["Image"].ToString();
                        blankCertModel.IsAvailable = bool.Parse(sqlDataReader["IsAvailable"].ToString());
                        blankCertModel.CreatedAt = DateTime.Parse(sqlDataReader["CreatedAt"].ToString());
                        blankCertModel.UpdatedAt = DateTime.Parse(sqlDataReader["UpdatedAt"].ToString());
                        blankCertModel.IsReturned = bool.Parse(sqlDataReader["IsReturned"].ToString());
                        blankCertModel.ReasonReturn = sqlDataReader["ReasonReturn"].ToString();
                        blankCertModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());
                        blankCertModel.ReferenceNumber = sqlDataReader["ReferenceNumber"].ToString();
                        blankCertModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
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

            return blankCertModel;
        }

        public List<BlankCertModel> SearchAvailableBlankCertBySerial(string serial)
        {
            List<BlankCertModel> blankCertModels = new List<BlankCertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Select * From [dbo].[TblPhoi] 
                                        where [dbo].[TblPhoi].[IsDeleted] = 0 and [dbo].[TblPhoi].[IsAvailable] = 1 and [dbo].[TblPhoi].[Serial] Like @Serial";
                SqlCommand command = new SqlCommand(queryString, conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Serial", "%" + serial + "%");
                conn.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        BlankCertModel blankCertModel = new BlankCertModel();
                        blankCertModel.Id = int.Parse(sqlDataReader["id"].ToString());
                        blankCertModel.Serial = sqlDataReader["Serial"].ToString();
                        blankCertModel.IsAvailable = bool.Parse(sqlDataReader["IsAvailable"].ToString());
                        blankCertModel.CreatedAt = DateTime.Parse(sqlDataReader["CreatedAt"].ToString());
                        blankCertModel.UpdatedAt = DateTime.Parse(sqlDataReader["UpdatedAt"].ToString());
                        blankCertModel.IsReturned = bool.Parse(sqlDataReader["IsReturned"].ToString());
                        blankCertModel.ReasonReturn = sqlDataReader["ReasonReturn"].ToString();
                        blankCertModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());
                        blankCertModel.ReferenceNumber = sqlDataReader["ReferenceNumber"].ToString();

                        blankCertModels.Add(blankCertModel);
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

            return blankCertModels;
        }

        public List<BlankCertModel> SearchAvailableBlankCertBySerialAndBlankCertType(string serial, int blankCertTypeId)
        {
            List<BlankCertModel> blankCertModels = new List<BlankCertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Select * From [dbo].[TblPhoi] 
                                        where [dbo].[TblPhoi].[IsDeleted] = 0 and [dbo].[TblPhoi].[IsAvailable] = 1 and [dbo].[TblPhoi].[Serial] Like @Serial and [dbo].[TblPhoi].[LoaiId] = @LoaiId";
                SqlCommand command = new SqlCommand(queryString, conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Serial", "%" + serial + "%");
                command.Parameters.AddWithValue("@LoaiId", blankCertTypeId);
                conn.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        BlankCertModel blankCertModel = new BlankCertModel();
                        blankCertModel.Id = int.Parse(sqlDataReader["id"].ToString());
                        blankCertModel.Serial = sqlDataReader["Serial"].ToString();
                        blankCertModel.IsAvailable = bool.Parse(sqlDataReader["IsAvailable"].ToString());
                        blankCertModel.CreatedAt = DateTime.Parse(sqlDataReader["CreatedAt"].ToString());
                        blankCertModel.UpdatedAt = DateTime.Parse(sqlDataReader["UpdatedAt"].ToString());
                        blankCertModel.IsReturned = bool.Parse(sqlDataReader["IsReturned"].ToString());
                        blankCertModel.ReasonReturn = sqlDataReader["ReasonReturn"].ToString();
                        blankCertModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());
                        blankCertModel.ReferenceNumber = sqlDataReader["ReferenceNumber"].ToString();

                        blankCertModels.Add(blankCertModel);
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

            return blankCertModels;
        }

        public List<BlankCertModel> SearchBlankCert(string serial, int blankCertTypeId, int status)
        {
            List<BlankCertModel> blankCertModels = new List<BlankCertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = "";
                switch (status)
                {
                    case 0: // all
                        queryString = @"select a.*, b.Name as 'Tenloai' From [dbo].[TblPhoi] as a
                                        left join [dbo].[tblLoai] as b
                                        on a.LoaiId = b.Id
                                        where a.[IsDeleted] = 0 
	                                         and a.Serial Like @Serial
	                                         and (-1 = @LoaiId or a.LoaiId = @LoaiId )";
                        break;
                    case 1: // available
                        queryString = @"select a.*, b.Name as 'Tenloai' From [dbo].[TblPhoi] as a
                                        left join [dbo].[tblLoai] as b
                                        on a.LoaiId = b.Id
                                        where a.[IsDeleted] = 0 
	                                         and a.Serial Like @Serial
	                                         and (-1 = @LoaiId or a.LoaiId = @LoaiId )	 
	                                         and (a.IsAvailable = 1 )";
                        break;
                    case 2: // return 
                        queryString = @"select a.*, b.Name as 'Tenloai' From [dbo].[TblPhoi] as a
                                        left join [dbo].[tblLoai] as b
                                        on a.LoaiId = b.Id
                                        where a.[IsDeleted] = 0 
	                                         and a.Serial Like @Serial
	                                         and (-1 = @LoaiId or a.LoaiId = @LoaiId )	 
	                                         and (a.IsReturned = 1 )";
                        break;
                    case 3: // used
                        queryString = @"select a.*, b.Name as 'Tenloai' From [dbo].[TblPhoi] as a
                                        left join [dbo].[tblLoai] as b
                                        on a.LoaiId = b.Id
                                        where a.[IsDeleted] = 0 
	                                         and a.Serial Like @Serial
	                                         and (-1 = @LoaiId or a.LoaiId = @LoaiId )	 
	                                         and (a.Id not in (select PhoiId from [dbo].[tblBang]))";
                        break;
                }
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Serial", "%" + serial +"%");
                sqlCommand.Parameters.AddWithValue("@LoaiId", blankCertTypeId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        BlankCertModel blankCertModel = new BlankCertModel();
                        blankCertModel.Id = int.Parse(sqlDataReader["id"].ToString());
                        blankCertModel.Serial = sqlDataReader["Serial"].ToString();
                        blankCertModel.IsAvailable = bool.Parse(sqlDataReader["IsAvailable"].ToString());
                        blankCertModel.CreatedAt = DateTime.Parse(sqlDataReader["CreatedAt"].ToString());
                        blankCertModel.UpdatedAt = DateTime.Parse(sqlDataReader["UpdatedAt"].ToString());
                        blankCertModel.IsReturned = bool.Parse(sqlDataReader["IsReturned"].ToString());
                        blankCertModel.ReasonReturn = sqlDataReader["ReasonReturn"].ToString();
                        blankCertModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());
                        blankCertModel.ReferenceNumber = sqlDataReader["ReferenceNumber"].ToString();
                        blankCertModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        blankCertModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();

                        blankCertModels.Add(blankCertModel);
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

            return blankCertModels;
        }

        public List<BlankCertModel> SearchBlankCertFormForAddingCert(string serial, int blankCertTypeId)
        {
            List<BlankCertModel> blankCertModels = new List<BlankCertModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Select * From [dbo].[TblPhoi] 
                                    where [IsDeleted] = 0 and [IsAvailable] = 1  and [dbo].[TblPhoi].[Serial] Like @Serial and [dbo].[TblPhoi].[LoaiId] = @LoaiId
                                    and id not in (select PhoiId from [dbo].[tblBang] )";
                SqlCommand command = new SqlCommand(queryString, conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Serial", "%" + serial + "%");
                command.Parameters.AddWithValue("@LoaiId", blankCertTypeId);
                conn.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        BlankCertModel blankCertModel = new BlankCertModel();
                        blankCertModel.Id = int.Parse(sqlDataReader["id"].ToString());
                        blankCertModel.Serial = sqlDataReader["Serial"].ToString();
                        blankCertModel.IsAvailable = bool.Parse(sqlDataReader["IsAvailable"].ToString());
                        blankCertModel.CreatedAt = DateTime.Parse(sqlDataReader["CreatedAt"].ToString());
                        blankCertModel.UpdatedAt = DateTime.Parse(sqlDataReader["UpdatedAt"].ToString());
                        blankCertModel.IsReturned = bool.Parse(sqlDataReader["IsReturned"].ToString());
                        blankCertModel.ReasonReturn = sqlDataReader["ReasonReturn"].ToString();
                        blankCertModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());
                        blankCertModel.ReferenceNumber = sqlDataReader["ReferenceNumber"].ToString();

                        blankCertModels.Add(blankCertModel);
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

            return blankCertModels;
        }

        public int Update(BlankCertModel blankCertModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblPhoi] 
                                    Set [Serial] = @Serial, [IsAvailable] = @IsAvailable, [UpdatedAt] = @UpdatedAt, [IsReturned] = @IsReturned, [ReasonReturn] = @ReasonReturn, [Image] = @Image, [LoaiId] = @BlankCertTypeId
                                    Where [Id] = @Id";
                try
                {
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@Serial", blankCertModel.Serial);
                    sqlCommand.Parameters.AddWithValue("@IsAvailable", blankCertModel.IsAvailable);
                    sqlCommand.Parameters.AddWithValue("@UpdatedAt", blankCertModel.UpdatedAt);
                    sqlCommand.Parameters.AddWithValue("@IsReturned", blankCertModel.IsReturned);
                    sqlCommand.Parameters.AddWithValue("@ReasonReturn", blankCertModel.ReasonReturn);
                    sqlCommand.Parameters.AddWithValue("@Image", blankCertModel.Image);
                    sqlCommand.Parameters.AddWithValue("@BlankCertTypeId", blankCertModel.BlankCertTypeId);
                    sqlCommand.Parameters.AddWithValue("@Id", blankCertModel.Id);

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
    }
}
