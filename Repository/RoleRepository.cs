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
    public interface IRoleRepository
    {
        List<RoleModel> GetAllRole();

        int AddRole(RoleModel roleModel);

        int RemoveRole(int roleId);

        int RemoveRoleAndClaim(int roleId);

        List<RoleModel> GetAllRoleByAccountId(int accountId);

        int AssignToAccount(int accountId, int roleId);

        int RemoveRoleAccount(int roleId);
    }
    public class RoleRepository : IRoleRepository
    {
        SqlConnection conn;

        public int AddRole(RoleModel roleModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblRole]
                                           ([RoleName]
                                           ,[RoleDescription]
                                           ,[IsDeleted])
	                                 Output Inserted.Id
                                     VALUES
                                           (@RoleName, @RoleDescription, 0)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@RoleName", roleModel.RoleName);
                sqlCommand.Parameters.AddWithValue("@RoleDescription", roleModel.RoleDescription);
                try
                {
                    int roleId = (int)sqlCommand.ExecuteScalar();
                    return roleId;
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

        public int AssignToAccount(int accountId, int roleId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblAccountRole]
                                           ([AccountId]
                                           ,[RoleId]
                                           ,[IsDeleted])
                                     VALUES
                                           (@AccountId, @RoleId, 0)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@RoleId", roleId);
                sqlCommand.Parameters.AddWithValue("@AccountId", accountId);
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

        public int RemoveRoleAccount(int roleId)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"Delete from [dbo].[tblAccountRole]
                                        Where RoleId = @RoleId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@RoleId", roleId);
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

        public List<RoleModel> GetAllRole()
        {
            List<RoleModel> roleModels = new List<RoleModel>();
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT * FROM [jb_cert].[dbo].[tblRole] where IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        RoleModel roleModel = new RoleModel();
                        roleModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        roleModel.RoleName = sqlDataReader["RoleName"].ToString();
                        roleModel.RoleDescription = sqlDataReader["RoleDescription"].ToString();
                        roleModel.IsDeleted = false;

                        roleModels.Add(roleModel);
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

            return roleModels;
        }

        public List<RoleModel> GetAllRoleByAccountId(int accountId)
        {
            List<RoleModel> roleModels = new List<RoleModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"select * from [dbo].[tblAccountRole]
                                        where AccountId = @AccountId and IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@AccountId", accountId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        RoleModel roleModel = new RoleModel();
                        roleModel.Id = int.Parse(sqlDataReader["RoleId"].ToString());
                        roleModel.IsDeleted = false;
                        roleModels.Add(roleModel);
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

            return roleModels;
        }

        public int RemoveRole(int roleId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblRole]
                                        Set IsDeleted = 1
                                        Where Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", roleId);
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

        public int RemoveRoleAndClaim(int roleId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"DELETE FROM [dbo].[tblRoleClaim]
                                       WHERE RoleId = @RoleId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@RoleId", roleId);
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
    }
}
