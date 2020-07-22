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
    public interface IMajorRepository
    {
        List<MajorModel> GetAll();
    }
    public class MajorRepository : IMajorRepository
    {
        SqlConnection conn;

        public List<MajorModel> GetAll()
        {
            List<MajorModel> majorModels = new List<MajorModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = "Select * From [dbo].[tblNganhDaoTao] Where IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                try
                {
                    while (sqlDataReader.Read())
                    {
                        MajorModel majorModel = new MajorModel();
                        majorModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        majorModel.MajorName = sqlDataReader["Nganhdaotao"].ToString();
                        majorModel.Note = sqlDataReader["Note"].ToString();
                        majorModel.IsDeleted = false;

                        majorModels.Add(majorModel);
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

            return majorModels;
        }
    }
}
