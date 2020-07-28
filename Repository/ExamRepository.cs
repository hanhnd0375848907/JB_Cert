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
    public interface IExamRepository
    {
        List<ExamModel> GetAll();

        ExamModel GetSingleById(int examId);

        List<ExamModel> GetBySchool(int schoolId);

        int AddExam(ExamModel examModel);
        
        int UpdateExam(ExamModel examModel);
        
        int DeleteExam(int examId);

        int DeleteAllExamBySchoolId(int schoolId);
    }
    public class ExamRepository : IExamRepository
    {
        private SqlConnection conn;

        public int AddExam(ExamModel examModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblKythi]
                                           ([Tenkythi]
                                           ,[Namkythi]
                                           ,[LoaiId]
                                           ,[TruongId]
                                           ,[IsDeleted])
                                     VALUES
                                        (@Tenkythi,@Namkythi,@LoaiId,@TruongId ,0)";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Tenkythi", examModel.ExamName);
                sqlCommand.Parameters.AddWithValue("@Namkythi", examModel.ExamDate);
                sqlCommand.Parameters.AddWithValue("@LoaiId", examModel.BlankCertTypeId);
                sqlCommand.Parameters.AddWithValue("@TruongId", examModel.SchoolId);

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

        public int DeleteAllExamBySchoolId(int schoolId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblKythi]
                                       SET IsDeleted = 1
                                       WHERE TruongId = @TruongId";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@TruongId", schoolId);

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

        public int DeleteExam(int examId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblKythi]
                                           SET IsDeleted = 1
                                         WHERE Id = @Id";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", examId);

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

        public List<ExamModel> GetAll()
        {
            List<ExamModel> examModels = new List<ExamModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Tentruong, c.Name as 'Tenloai'
                                      FROM [dbo].[tblKythi] as a
                                      left join [dbo].[tblTruong] as b
                                      on a.TruongId = b.Id
                                      left join [dbo].[tblLoai] as c
                                      on a.LoaiId = c.Id
                                      Where a.IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        ExamModel examModel = new ExamModel();
                        examModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        examModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        examModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        examModel.ExamName = sqlDataReader["Tenkythi"].ToString();
                        examModel.ExamDate = DateTime.Parse(sqlDataReader["Namkythi"].ToString());
                        examModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        examModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        examModel.IsDeleted = false;
                        examModels.Add(examModel);
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

            return examModels;
        }

        public List<ExamModel> GetBySchool(int schoolId)
        {
            List<ExamModel> examModels = new List<ExamModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Tentruong, c.Name as 'Tenloai'
                                      FROM [dbo].[tblKythi] as a
                                      left join [dbo].[tblTruong] as b
                                      on a.TruongId = b.Id
                                      left join [dbo].[tblLoai] as c
                                      on a.LoaiId = c.Id
                                      Where a.IsDeleted = 0 and a.TruongId = @TruongId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@TruongId", schoolId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        ExamModel examModel = new ExamModel();
                        examModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        examModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        examModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        examModel.ExamName = sqlDataReader["Tenkythi"].ToString();
                        examModel.ExamDate = DateTime.Parse(sqlDataReader["Namkythi"].ToString());
                        examModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        examModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        examModel.IsDeleted = false;
                        examModels.Add(examModel);
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

            return examModels;
        }

        public ExamModel GetSingleById(int examId)
        {
            ExamModel examModel = new ExamModel();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Tentruong, c.Name as 'Tenloai'
                                      FROM [dbo].[tblKythi] as a
                                      left join [dbo].[tblTruong] as b
                                      on a.TruongId = b.Id
                                      left join [dbo].[tblLoai] as c
                                      on a.LoaiId = c.Id
                                      Where a.IsDeleted = 0 and a.Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", examId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        examModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        examModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        examModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        examModel.ExamName = sqlDataReader["Tenkythi"].ToString();
                        examModel.ExamDate = DateTime.Parse(sqlDataReader["Namkythi"].ToString());
                        examModel.SchoolId = int.Parse(sqlDataReader["TruongId"].ToString());
                        examModel.SchoolName = sqlDataReader["Tentruong"].ToString();
                        examModel.IsDeleted = false;
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

            return examModel;
        }

        public int UpdateExam(ExamModel examModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblKythi]
                                           SET [Tenkythi] = @Tenkythi
                                              ,[Namkythi] = @Namkythi
                                              ,[LoaiId] = @LoaiId
                                              ,[TruongId] = @TruongId
                                         WHERE Id = @Id";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Tenkythi", examModel.ExamName);
                sqlCommand.Parameters.AddWithValue("@Namkythi", examModel.ExamDate);
                sqlCommand.Parameters.AddWithValue("@LoaiId", examModel.BlankCertTypeId);
                sqlCommand.Parameters.AddWithValue("@TruongId", examModel.SchoolId);
                sqlCommand.Parameters.AddWithValue("@Id", examModel.Id);

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
