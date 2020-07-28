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
    public interface ICopiedCertRepository
    {
        List<CopiedCertModel> GetAllCopiedCert();

        int GetNumberOfCopiedCertByStudentId(int studentId);

        int AddManyCopiedCerts(List<BlankCertModel> blankCertModels, List<StudentModel> studentModels, string certName);
    }
    public class CopiedCertRepository : ICopiedCertRepository
    {
        private SqlConnection conn;

        public List<CopiedCertModel> GetAllCopiedCert()
        {
            List<CopiedCertModel> copiedCertModels = new List<CopiedCertModel>();
            using(conn = JBCertConnection.Instance)
            {
                string queryString = "";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        CopiedCertModel copiedCertModel = new CopiedCertModel();


                        copiedCertModels.Add(copiedCertModel);
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

            return copiedCertModels;
        }

        public int GetNumberOfCopiedCertByStudentId(int studentId)
        {
            int count = 0;
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.HocsinhId, count(a.Id) as 'Soluongbansao' FROM [dbo].[tblBansao] as a
	                                    where a.HocsinhId = @HocsinhId
	                                    Group by a.HocsinhId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@HocsinhId", studentId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        count = int.Parse(sqlDataReader["Soluongbansao"].ToString());
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
            return count;

        }

        public int AddManyCopiedCerts(List<BlankCertModel> blankCertModels, List<StudentModel> studentModels, string certName)
        {
            int rowEffected = 0;
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblBansao]
                                                    ([HocsinhId]
                                                    ,[XeploaiId]
                                                    ,[Tenbang]
                                                    ,[PhoiId]
                                                    ,[Sovaosobansao]
                                                    ,[BangId]
                                                    ,[IsGranted]
                                                    ,[IsPrinted]
                                                    ,[IsDeleted])
                                        VALUES (@HocsinhId,@XeploaiId,@Tenbang,@PhoiId,@Sovaosobansao,@BangId,0,0,0)";
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                SqlCommand sqlCommand = null;
                try
                {
                    for (int i = 0; i < blankCertModels.Count; i++)
                    {
                        sqlCommand = new SqlCommand(queryString, conn, sqlTransaction);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@HocsinhID", studentModels[i].Id);
                        sqlCommand.Parameters.AddWithValue("@XeploaiId", studentModels[i].RankingId);
                        sqlCommand.Parameters.AddWithValue("@Tenbang", certName);
                        sqlCommand.Parameters.AddWithValue("@PhoiId", blankCertModels[i].Id);
                        sqlCommand.Parameters.AddWithValue("@Sovaosobansao", blankCertModels[i].ReferenceNumber);
                        sqlCommand.Parameters.AddWithValue("@BangId", studentModels[i].CertId);
                        rowEffected += sqlCommand.ExecuteNonQuery();
                    }
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

            return rowEffected;
        }
    }
}
