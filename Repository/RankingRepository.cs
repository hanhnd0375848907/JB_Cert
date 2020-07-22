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
    public interface IRankingRepository
    {
        List<RankingModel> GetAll();
    }

    public class RankingRepository : IRankingRepository
    {
        SqlConnection conn;

        public List<RankingModel> GetAll()
        {
            List<RankingModel> rankingModels = new List<RankingModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = "Select * From [dbo].[tblXeploai] Where IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        RankingModel rankingModel = new RankingModel();
                        rankingModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        rankingModel.RankingName = sqlDataReader["Tenxeploai"].ToString();
                        rankingModel.Note = sqlDataReader["Ghichu"].ToString();
                        rankingModel.IsDeleted = false;

                        rankingModels.Add(rankingModel);
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

            return rankingModels;
        }
    }
}
