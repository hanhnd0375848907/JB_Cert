using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IAccountService
    {
        List<ClaimModel> GetClaimsByAccountId(int accountId);

        AccountModel GetSingleAccountByUsername(string username);

        List<AccountModel> GetAllAccount();

        List<AccountModel> SearchAccount(string username, string email, string phoneNumber, int isActive);

        AccountModel GetSingleAccountById(int accountId);

        int UpdateAccountInformation(AccountModel accountModel);

        int LockManyAccount(List<int> accountIds);

        int ActiveManyAccount(List<int> accountIds);

        int DeleteManyAccount(List<int> accountIds);

        List<RoleModel> GetAllRole();

        List<ClaimModel> GetAllPermission();

        int AddRole(RoleModel roleModel);

        int DeleteManyRole(List<int> roleIds);

        List<ClaimModel> GetAllClaimByRoleId(int roleId);

        int UpdateManyRole(List<int> roleIds, List<int> claimIds);

        List<RoleModel> GetAllRoleByAccountId(int accountId);

        int UpdateAccountRole(List<int> accountIds, List<int> roleIds);

        int UpdatePassword(int accountId, string password);

        int CreateAccount(AccountModel accountModel, List<int> roleIds);

    }
    public class AccountService : IAccountService
    {
        private IClaimRepository claimRepository;
        private IAccountRepository accountRepository;
        private IRoleRepository roleRepository;

        public AccountService()
        {
            claimRepository = new ClaimRepository();
            accountRepository = new AccountRepository();
            roleRepository = new RoleRepository();
        }

        public int ActiveManyAccount(List<int> accountIds)
        {
            try
            {
                int result = 0;
                foreach (int accountId in accountIds)
                {
                    result += accountRepository.ActiveAccount(accountId);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddRole(RoleModel roleModel)
        {
            try
            {
                int roleId = roleRepository.AddRole(roleModel);
                int result = 1;
                foreach(ClaimModel claimModel in roleModel.ClaimModels)
                {
                    result += claimRepository.AssignClaimToRole(roleId, claimModel.Id);
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int CreateAccount(AccountModel accountModel, List<int> roleIds)
        {
            try
            {
                int result = 0;
                int accountId = accountRepository.CreateAccount(accountModel);
                result += 1;
                foreach (int roleId in roleIds)
                {
                    result += roleRepository.AssignToAccount(accountId, roleId);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManyAccount(List<int> accountIds)
        {
            try
            {
                int result = 0;
                foreach (int accountId in accountIds)
                {
                    result += accountRepository.DeleteAccount(accountId);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManyRole(List<int> roleIds)
        {
            try
            {
                int result = 0;
                foreach(int roleId in roleIds)
                {
                    result += roleRepository.RemoveRole(roleId);
                    result += claimRepository.RemoveAllClaimInRole(roleId);
                    result += roleRepository.RemoveRoleAccount(roleId);
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountModel> GetAllAccount()
        {
            try
            {
                return accountRepository.GetAllAccount();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClaimModel> GetAllClaimByRoleId(int roleId)
        {
            try
            {
                return claimRepository.GetAllClaimByRoleId(roleId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClaimModel> GetAllPermission()
        {
            try
            {
                return claimRepository.GetAllClaim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RoleModel> GetAllRole()
        {
            try
            {
                return roleRepository.GetAllRole();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RoleModel> GetAllRoleByAccountId(int accountId)
        {
            try
            {
                return roleRepository.GetAllRoleByAccountId(accountId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClaimModel> GetClaimsByAccountId(int accountId)
        {
            try
            {
                return claimRepository.GetClaimsByAccountId(accountId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public AccountModel GetSingleAccountById(int accountId)
        {
            try
            {
                return accountRepository.GetSingleAccountById(accountId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AccountModel GetSingleAccountByUsername(string username)
        {
            try
            {
                return accountRepository.GetSingleAccountByUsername(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int LockManyAccount(List<int> accountIds)
        {
            try
            {
                int result = 0;
                foreach(int accountId in accountIds)
                {
                    result += accountRepository.LockAccount(accountId);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AccountModel> SearchAccount(string username, string email, string phoneNumber, int isActive)
        {
            try
            {
                return accountRepository.SearchAccount(username, email, phoneNumber, isActive);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateAccountInformation(AccountModel accountModel)
        {
            try
            {
                return accountRepository.UpdateAccountInformation(accountModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateAccountRole(List<int> accountIds, List<int> roleIds)
        {
            try
            {
                int result = 0;
                foreach(int accountId in accountIds)
                {
                    result += accountRepository.RemoveAccountAndRole(accountId);
                    foreach (int roleId in roleIds)
                    {
                        result += roleRepository.AssignToAccount(accountId, roleId);
                    }

                }

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateManyRole(List<int> roleIds, List<int> claimIds)
        {
            try
            {
                int result = 0;
                foreach(int roleId in roleIds)
                {
                    result += roleRepository.RemoveRoleAndClaim(roleId);
                    foreach (int claimId in claimIds)
                    {
                        result += claimRepository.AssignClaimToRole(roleId, claimId);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdatePassword(int accountId, string password)
        {
            try
            {
                return accountRepository.UpdatePassword(accountId, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
