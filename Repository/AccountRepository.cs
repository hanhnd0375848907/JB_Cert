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
    public interface IAccountRepository
    {
        AccountModel GetSingleAccountByUsername(string username);

        List<AccountModel> GetAllAccount();

        List<AccountModel> SearchAccount(string username, string email, string phoneNumber, int isActive);

        AccountModel GetSingleAccountById(int accountId);

        int UpdateAccountInformation(AccountModel accountModel);

        int LockAccount(int accountId);

        int ActiveAccount(int accountId);

        int DeleteAccount(int accountId);

        int RemoveAccountAndRole(int accountId);

        int UpdatePassword(int accountId, string password);

        int CreateAccount(AccountModel accountModel);
    }
    public class AccountRepository : IAccountRepository
    {
        private SqlConnection conn;

        public int ActiveAccount(int accountId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblAccount]
                                       Set IsActive = 1
                                       Where Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", accountId);
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

        public int CreateAccount(AccountModel accountModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblAccount]
                                           ([Username]
                                           ,[Password]
                                           ,[PhoneNumber]
                                           ,[Email]
                                           ,[IsActive]
                                           ,[IsDeleted])
                                     Output Inserted.Id
                                     VALUES
                                           (@Username, @Password, @PhoneNumber, @Email, 1, 0)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Username", accountModel.Username);
                sqlCommand.Parameters.AddWithValue("@Password", accountModel.Password);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", accountModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Email", accountModel.Email);
                try
                {
                    int accountId = (int)sqlCommand.ExecuteScalar();
                    return accountId;
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

        public int DeleteAccount(int accountId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblAccount]
                                       Set IsDeleted = 1
                                       Where Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", accountId);
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

        public List<AccountModel> GetAllAccount()
        {
            List<AccountModel> accountModels = new List<AccountModel>();

            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.RoleId, c.RoleName, c.RoleDescription FROM [dbo].[tblAccount] as a
	                                    left join [dbo].[tblAccountRole] as b
	                                    on a.Id = b.AccountId
	                                    left join [dbo].[tblRole] as c
	                                    on b.RoleId = c.Id
	                                    where a.IsDeleted = 0";

                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        if (accountModels.Any(x => x.Id == int.Parse(sqlDataReader["Id"].ToString())))
                        {
                            AccountModel accountModel = accountModels.Where(x => x.Id == int.Parse(sqlDataReader["Id"].ToString())).FirstOrDefault();
                            accountModel.RoleModels.Add(new RoleModel()
                            {
                                RoleName = sqlDataReader["RoleName"].ToString(),
                                RoleDescription = sqlDataReader["RoleDescription"].ToString()
                            });
                        }
                        else
                        {
                            AccountModel accountModel = new AccountModel();
                            accountModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                            accountModel.Username = sqlDataReader["Username"].ToString();
                            accountModel.Password = sqlDataReader["Password"].ToString();
                            accountModel.Email = sqlDataReader["Email"].ToString();
                            accountModel.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();
                            accountModel.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString());
                            if (!string.IsNullOrEmpty(sqlDataReader["RoleId"].ToString()) && sqlDataReader["RoleId"] != null)
                            {
                                accountModel.RoleModels = new List<RoleModel>()
                                {

                                    new RoleModel() // chưa sửa khi roleId null, roleName null...
                                    {
                                        Id = int.Parse(sqlDataReader["RoleId"].ToString()),
                                        RoleName = sqlDataReader["RoleName"].ToString(),
                                        RoleDescription = sqlDataReader["RoleDescription"].ToString()
                                    }
                                };
                            }

                            accountModel.IsDeleted = false;
                            accountModels.Add(accountModel);
                        }

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

            return accountModels;
        }

        public AccountModel GetSingleAccountById(int accountId)
        {
            AccountModel accountModel = null;
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT * FROM [dbo].[tblAccount]
                                        where IsDeleted = 0 and Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", accountId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        accountModel = new AccountModel();
                        accountModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        accountModel.Username = sqlDataReader["Username"].ToString();
                        accountModel.Password = sqlDataReader["Password"].ToString();
                        accountModel.Email = sqlDataReader["Email"].ToString();
                        accountModel.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();
                        accountModel.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString());
                        accountModel.IsDeleted = false;
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

            return accountModel;
        }

        public AccountModel GetSingleAccountByUsername(string username)
        {
            AccountModel accountModel = null;
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT * FROM [dbo].[tblAccount]
                                        where Username = @Username and IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Username", username);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        accountModel = new AccountModel();
                        accountModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        accountModel.Password = sqlDataReader["Password"].ToString();
                        accountModel.Username = sqlDataReader["Username"].ToString();
                        accountModel.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString());
                        accountModel.IsDeleted = false;
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

            return accountModel;
        }

        public int LockAccount(int accountId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblAccount]
                                       Set IsActive = 0
                                       Where Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", accountId);
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

        public int RemoveAccountAndRole(int accountId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Delete [dbo].[tblAccountRole]
                                       Where AccountId = @AccountId and IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
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

        public List<AccountModel> SearchAccount(string username, string email, string phoneNumber, int isActive)
        {
            List<AccountModel> accountModels = new List<AccountModel>();

            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.RoleId, c.RoleName, c.RoleDescription FROM [dbo].[tblAccount] as a
	                                    left join [dbo].[tblAccountRole] as b
	                                    on a.Id = b.AccountId
	                                    left join [dbo].[tblRole] as c
	                                    on b.RoleId = c.Id
	                                    where a.IsDeleted = 0 and a.Username like @Username and a.Email like @Email
                                                and a.PhoneNumber like @PhoneNumber and ((@IsActive = -1) or a.IsActive = @IsActive)";

                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Username", "%" + username + "%");
                sqlCommand.Parameters.AddWithValue("@Email", "%" + email + "%");
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", "%" + phoneNumber + "%");
                sqlCommand.Parameters.AddWithValue("@IsActive", isActive);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        if (accountModels.Any(x => x.Id == int.Parse(sqlDataReader["Id"].ToString())))
                        {
                            AccountModel accountModel = accountModels.Where(x => x.Id == int.Parse(sqlDataReader["Id"].ToString())).FirstOrDefault();
                            accountModel.RoleModels.Add(new RoleModel()
                            {
                                RoleName = sqlDataReader["RoleName"].ToString(),
                                RoleDescription = sqlDataReader["RoleDescription"].ToString()
                            });
                        }
                        else
                        {
                            AccountModel accountModel = new AccountModel();
                            accountModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                            accountModel.Username = sqlDataReader["Username"].ToString();
                            accountModel.Password = sqlDataReader["Password"].ToString();
                            accountModel.Email = sqlDataReader["Email"].ToString();
                            accountModel.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();
                            accountModel.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString());
                            accountModel.RoleModels = new List<RoleModel>()
                            {
                                new RoleModel()
                                {
                                    Id = int.Parse(sqlDataReader["RoleId"].ToString()),
                                    RoleName = sqlDataReader["RoleName"].ToString(),
                                    RoleDescription = sqlDataReader["RoleDescription"].ToString()
                                }
                            };
                            accountModel.IsDeleted = false;
                            accountModels.Add(accountModel);
                        }

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

            return accountModels;
        }

        public int UpdateAccountInformation(AccountModel accountModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblAccount]
                                       Set Username = @Username, Email = @Email, PhoneNumber = @PhoneNumber, IsActive = @IsActive
                                       Where Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Username", accountModel.Username);
                sqlCommand.Parameters.AddWithValue("@Email", accountModel.Email);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", accountModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@IsActive", accountModel.IsActive);
                sqlCommand.Parameters.AddWithValue("@Id", accountModel.Id);
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

        public int UpdatePassword(int accountId, string password)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"Update [dbo].[tblAccount]
                                       Set Password = @Password
                                       Where Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", accountId);
                sqlCommand.Parameters.AddWithValue("@Password", password);
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
