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
    public interface IBlankCertTypeRepository
    {
        List<BlankCertTypeModel> GetAll();

        int AddBlankCertType(BlankCertTypeModel blankCertTypeModel);

        BlankCertTypeModel GetSingleBlankCertTypeById(int blankCertTypeId);

        int UpdateBlanCertType(BlankCertTypeModel blankCertTypeModel);

        int DeleteBlankCertType(int blankCertTypeId);
    }
    public class BlankCertTypeRepository : IBlankCertTypeRepository
    {
        SqlConnection conn;

        public int AddBlankCertType(BlankCertTypeModel blankCertTypeModel)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblLoai]
                                           ([Name]
                                           ,[Note]
                                           ,[IsDeleted])
                                     VALUES(@Name, @Note, 0) ";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Name", blankCertTypeModel.Name);
                sqlCommand.Parameters.AddWithValue("@Note", blankCertTypeModel.Note);
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

        public int DeleteBlankCertType(int blankCertTypeId)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblLoai] 
                                        Set [IsDeleted] = 1
                                        Where[Id] = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", blankCertTypeId);
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

        public List<BlankCertTypeModel> GetAll()
        {
            List<BlankCertTypeModel> blankCertTypeModels = new List<BlankCertTypeModel>();
            using(conn = JBCertConnection.Instance)
            {
                string queryString = "Select * From [dbo].[tblLoai] where [IsDeleted] = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        BlankCertTypeModel blankCertTypeModel = new BlankCertTypeModel();
                        blankCertTypeModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        blankCertTypeModel.Name = sqlDataReader["Name"].ToString();
                        blankCertTypeModel.Note = sqlDataReader["Note"].ToString();
                        blankCertTypeModels.Add(blankCertTypeModel);
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
            return blankCertTypeModels;
        }

        public BlankCertTypeModel GetSingleBlankCertTypeById(int blankCertTypeId)
        {
            BlankCertTypeModel blankCertTypeModel = null;
            using (conn = JBCertConnection.Instance)
            {
                string queryString = "Select * From [dbo].[tblLoai] where [Id] = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", blankCertTypeId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        blankCertTypeModel = new BlankCertTypeModel();
                        blankCertTypeModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        blankCertTypeModel.Name = sqlDataReader["Name"].ToString();
                        blankCertTypeModel.Note = sqlDataReader["Note"].ToString();
                        blankCertTypeModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());
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

            return blankCertTypeModel;

        }

        public int UpdateBlanCertType(BlankCertTypeModel blankCertTypeModel)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblLoai] 
                                        Set [Name] = @Name, [Note] = @Note
                                        Where [Id] = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Name", blankCertTypeModel.Name);
                sqlCommand.Parameters.AddWithValue("@Note", blankCertTypeModel.Note);
                sqlCommand.Parameters.AddWithValue("@Id", blankCertTypeModel.Id);
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
