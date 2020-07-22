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
    public interface IDepartmentOfEducationAndTrainingRepository
    {
        DepartmentOfEducationAndTrainingModel GetInfo();

        int UpdateInfor(DepartmentOfEducationAndTrainingModel departmentOfEducationAndTrainingModel);
    }
    public class DepartmentOfEducationAndTrainingRepository : IDepartmentOfEducationAndTrainingRepository
    {
        SqlConnection conn;
        public DepartmentOfEducationAndTrainingModel GetInfo()
        {
            DepartmentOfEducationAndTrainingModel departmentOfEducationAndTrainingModel = new DepartmentOfEducationAndTrainingModel();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT *
                                    FROM [dbo].[tblSogiaoduc]";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        departmentOfEducationAndTrainingModel.Name = sqlDataReader["Tenso"].ToString();
                        departmentOfEducationAndTrainingModel.PhoneNumber = sqlDataReader["Sodienthoai"].ToString();
                        departmentOfEducationAndTrainingModel.Province = sqlDataReader["Tinh"].ToString();
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

            return departmentOfEducationAndTrainingModel;
        }

        public int UpdateInfor(DepartmentOfEducationAndTrainingModel departmentOfEducationAndTrainingModel)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblSogiaoduc]
                                       SET [Tenso] = @Tenso
                                          ,[Sodienthoai] = @Sodienthoai
                                          ,[Tinh] = @Tinh";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Tenso", departmentOfEducationAndTrainingModel.Name);
                sqlCommand.Parameters.AddWithValue("@Sodienthoai", departmentOfEducationAndTrainingModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Tinh", departmentOfEducationAndTrainingModel.Province);
                try
                {
                    int rowEffected = sqlCommand.ExecuteNonQuery();
                    return rowEffected;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
