using Common;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert.Authorization
{
    public static class Auth
    {
        public static bool HavePermissions(string [] permissions)
        {
            try
            {
                int currentUserId = CurrentUser.Id;
                string currentUsername = CurrentUser.Username;
                if (currentUsername == "Admin")
                {
                    return true;
                }
                IAccountService accountService = new AccountService();
                List<string> claims = accountService.GetClaimsByAccountId(currentUserId).Select(x => x.ClaimName).ToList();
                foreach (string claim in claims)
                {
                    if (permissions.Contains(claim))
                    {
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
