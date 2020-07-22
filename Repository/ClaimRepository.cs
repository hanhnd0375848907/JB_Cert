using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IClaimRepository
    {
        List<ClaimModel> GetClaimsByAccountId(int accountId);

        List<ClaimModel> GetAllClaim();

        int AssignClaimToRole(int roleId, int claimId);

        int RemoveAllClaimInRole(int roleId);

        List<ClaimModel> GetAllClaimByRoleId(int roleId);

    }
    public class ClaimRepository : IClaimRepository
    {
        private SqlConnection conn;

        public int AssignClaimToRole(int roleId, int claimId)
        {
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblRoleClaim]
                                           ([RoleId]
                                           ,[ClaimId]
                                           ,[IsDeleted])
                                     VALUES
                                           (@RoleId, @ClaimId, 0)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@RoleId", roleId);
                sqlCommand.Parameters.AddWithValue("@ClaimId", claimId);
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

        public List<ClaimModel> GetAllClaim()
        {
            List<ClaimModel> claimModels = new List<ClaimModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Select * From [dbo].[tblClaim] where IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        ClaimModel claimModel = new ClaimModel();
                        claimModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        claimModel.ClaimName = sqlDataReader["ClaimName"].ToString();
                        claimModel.ClaimDescription = sqlDataReader["ClaimDescription"].ToString();
                        claimModel.IsDeleted = false;

                        claimModels.Add(claimModel);
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

            return claimModels;
        }

        public List<ClaimModel> GetAllClaimByRoleId(int roleId)
        {
            List<ClaimModel> claimModels = new List<ClaimModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"select * from [tblRoleClaim]
                                        where roleId = @RoleId and IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@RoleId", roleId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        ClaimModel claimModel = new ClaimModel();
                        claimModel.Id = int.Parse(sqlDataReader["ClaimId"].ToString());

                        claimModels.Add(claimModel);
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
            return claimModels;
        }

        public List<ClaimModel> GetClaimsByAccountId(int accountId)
        {
            List<ClaimModel> claimModels = new List<ClaimModel>();
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT d.* FROM [dbo].[tblAccount] as a
	                                    left join [dbo].[tblAccountRole] as b
	                                    on a.Id = b.AccountId
	                                    left join [dbo].[tblRoleClaim] as c
	                                    on b.RoleId = c.RoleId
	                                    left join [dbo].[tblClaim] as d
	                                    on c.ClaimId = d.Id
	                                    where a.id = @AccountId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@AccountId", accountId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        ClaimModel claimModel = new ClaimModel();
                        claimModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        claimModel.ClaimName = sqlDataReader["ClaimName"].ToString();
                        claimModel.ClaimDescription = sqlDataReader["ClaimDescription"].ToString();
                        claimModel.IsDeleted = false;

                        claimModels.Add(claimModel);
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

            return claimModels;
        }

        public int RemoveAllClaimInRole(int roleId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblRoleClaim]
                                       Set IsDeleted = 1
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
    }
}
