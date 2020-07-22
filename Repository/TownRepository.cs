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
    public interface ITownRepository
    {
        List<TownModel> GetAll();
    }
    public class TownRepository : ITownRepository
    {
        SqlConnection conn;

        public List<TownModel> GetAll()
        {
            List<TownModel> townModels = new List<TownModel>();
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT *
                                      FROM [jb_cert].[dbo].[tblHuyen]
                                      Where [tblHuyen].[IsDeleted] = 0";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        TownModel townModel = new TownModel();
                        townModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        townModel.TownName = sqlDataReader["Ten"].ToString();
                        townModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        townModel.Address = sqlDataReader["Diachi"].ToString();
                        townModel.Note = sqlDataReader["Ghichu"].ToString();
                        townModel.IsDeleted = false;

                        townModels.Add(townModel);
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

            return townModels;
        }
    }
}
