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
    public interface ILearningModeRepository
    {
        List<LearningModeModel> GetAll();
    }
    public class LearningModeRepository : ILearningModeRepository
    {
        SqlConnection conn;

        public List<LearningModeModel> GetAll()
        {
            List<LearningModeModel> learningModeModels = new List<LearningModeModel>();
            using(conn = JBCertConnection.Instance)
            {
                string queryString = "Select * From [dbo].[tblHinhthucdaotao] Where IsDeleted = 0";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        LearningModeModel learningModeModel = new LearningModeModel();
                        learningModeModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        learningModeModel.LearningModeName = sqlDataReader["Hinhthucdaotao"].ToString();
                        learningModeModel.Note = sqlDataReader["Ghichu"].ToString();
                        learningModeModel.IsDeleted = false;

                        learningModeModels.Add(learningModeModel);
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

            return learningModeModels;
        }
    }
}
