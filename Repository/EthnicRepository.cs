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
    public interface IEthnicRepository
    {
        List<EthnicModel> GetAll();
    }
    public class EthnicRepository : IEthnicRepository
    {
        SqlConnection conn;

        public List<EthnicModel> GetAll()
        {
            List<EthnicModel> ethnicModels = new List<EthnicModel>();
            using(conn = JBCertConnection.Instance)
            {
                string queryString = "Select * From [dbo].[tblDantoc] Where [IsDeleted] = 0";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        EthnicModel ethnicModel = new EthnicModel();
                        ethnicModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        ethnicModel.EthnicName = sqlDataReader["TenDantoc"].ToString();
                        ethnicModel.Note = sqlDataReader["Ghichu"].ToString();
                        ethnicModel.IsDeleted = false;

                        ethnicModels.Add(ethnicModel);
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

            return ethnicModels;
        }
    }
}
