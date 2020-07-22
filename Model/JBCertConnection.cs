using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class JBCertConnection
    {
        private static SqlConnection instance = null;
        private static readonly object padlock = new object();

        public JBCertConnection()
        {

        }

        public static SqlConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            string server = @".\SQLEXPRESS";
                            string database = "jb_cert";
                            //string connectionString = "Data Source=" + server + ";Initial Catalog=" + database + ";Trusted_Connection=Yes;";
                            string connectionString = "Server=tcp:jbtech.database.windows.net,1433;Initial Catalog=Jb_Cert;Persist Security Info=False;User ID=jbadmin;Password=JBTech2020;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                            instance = new SqlConnection(connectionString);
                        }
                    }
                }
                else
                {
                    string server = @".\SQLEXPRESS";
                    string database = "jb_cert";
                    //string connectionString = "Data Source=" + server + ";Initial Catalog=" + database + ";Trusted_Connection=Yes;";
                    string connectionString = "Server=tcp:jbtech.database.windows.net,1433;Initial Catalog=Jb_Cert;Persist Security Info=False;User ID=jbadmin;Password=JBTech2020;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    instance.ConnectionString = connectionString;
                }
                return instance;
            }
        }
    }
}
