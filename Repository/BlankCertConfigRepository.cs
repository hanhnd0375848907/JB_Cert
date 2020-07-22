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
    public interface IBlankCertConfigRepository
    {
        List<BlankCertConfigModel> GetAll();

        int Add(BlankCertConfigModel blankCertConfigModel);

        BlankCertConfigModel GetSingleByBlankCertType(int blankCertTypeId);
    }
    public class BlankCertConfigRepository : IBlankCertConfigRepository
    {
        SqlConnection conn;

        public int Add(BlankCertConfigModel blankCertConfigModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string addCertQueryString = @"INSERT INTO [dbo].[tblThongsophoi]
                                               ([TruongX],[TruongY],[HovatenX],[HovatenY]
                                               ,[GioitinhX],[GioitinhY],[NgaysinhX],[NgaysinhY]
                                               ,[NganhdaotaoX],[NganhdaotaoY],[XeploaiX],[XeploaiY]
                                               ,[HinhthucdaotaoX],[HinhthucdaotaoY],[NgaytaovanbangX],[NgaytaovanbangY]
                                               ,[NoisinhX],[NoisinhY],[SohieuX],[SohieuY],[SovaosoX],[SovaosoY]
                                               ,[KhoathiX],[KhoathiY],[DantocX],[DantocY]
                                               ,[DiemthiX],[DiemthiY],[LoaiId],[IsActive],[UpdatedAt],[Ghichu],[IsDeleted])
                                            Output INSERTED.Id
                                            VALUES
                                               (@TruongX,@TruongY,@HovatenX,@HovatenY,@GioitinhX,@GioitinhY,@NgaysinhX
			                                    ,@NgaysinhY,@NganhdaotaoX,@NganhdaotaoY,@XeploaiX,@XeploaiY,@HinhthucdaotaoX,@HinhthucdaotaoY
			                                    ,@NgaytaovanbangX,@NgaytaovanbangY,@NoisinhX,@NoisinhY,@SohieuX,@SohieuY,@SovaosoX
			                                    ,@SovaosoY,@KhoathiX,@KhoathiY,@DantocX,@DantocY,@DiemthiX,@DiemthiY
			                                    ,@LoaiId,@IsActive,@UpdatedAt,@Ghichu,0)";

                string updateQueryString = @"Update [dbo].[tblThongsophoi]
                                            Set [IsActive] = 0
                                            Where [LoaiId] = @LoaiId and [Id] <> @Id";
                conn.Open();
                SqlCommand sqlCommand = null;
                SqlTransaction sqlTransaction = conn.BeginTransaction();

                try
                {
                    sqlCommand = new SqlCommand(addCertQueryString, conn, sqlTransaction);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@TruongX", blankCertConfigModel.SchoolX);
                    sqlCommand.Parameters.AddWithValue("@TruongY", blankCertConfigModel.SchoolY);
                    sqlCommand.Parameters.AddWithValue("@HovatenX", blankCertConfigModel.FullNameX);
                    sqlCommand.Parameters.AddWithValue("@HovatenY", blankCertConfigModel.FullNameY);
                    sqlCommand.Parameters.AddWithValue("@GioitinhX", blankCertConfigModel.GenderX);
                    sqlCommand.Parameters.AddWithValue("@GioitinhY", blankCertConfigModel.GenderY);
                    sqlCommand.Parameters.AddWithValue("@NgaysinhX", blankCertConfigModel.DobX);
                    sqlCommand.Parameters.AddWithValue("@NgaysinhY", blankCertConfigModel.DobY);
                    sqlCommand.Parameters.AddWithValue("@NganhdaotaoX", blankCertConfigModel.MajorX);
                    sqlCommand.Parameters.AddWithValue("@NganhdaotaoY", blankCertConfigModel.MajorY);
                    sqlCommand.Parameters.AddWithValue("@XeploaiX", blankCertConfigModel.RankingX);
                    sqlCommand.Parameters.AddWithValue("@XeploaiY", blankCertConfigModel.RankingY);
                    sqlCommand.Parameters.AddWithValue("@HinhthucdaotaoX", blankCertConfigModel.LearningModeX);
                    sqlCommand.Parameters.AddWithValue("@HinhthucdaotaoY", blankCertConfigModel.LearningModeY);
                    sqlCommand.Parameters.AddWithValue("@NgaytaovanbangX", blankCertConfigModel.CreatedDateX);
                    sqlCommand.Parameters.AddWithValue("@NgaytaovanbangY", blankCertConfigModel.CreatedDateY);
                    sqlCommand.Parameters.AddWithValue("@NoisinhX", blankCertConfigModel.BornedAddressX);
                    sqlCommand.Parameters.AddWithValue("@NoisinhY", blankCertConfigModel.BornedAddressY);
                    sqlCommand.Parameters.AddWithValue("@SohieuX", blankCertConfigModel.SerialX);
                    sqlCommand.Parameters.AddWithValue("@SohieuY", blankCertConfigModel.SerialY);
                    sqlCommand.Parameters.AddWithValue("@SovaosoX", blankCertConfigModel.ReferenceNumberX);
                    sqlCommand.Parameters.AddWithValue("@SovaosoY", blankCertConfigModel.ReferenceNumberY);
                    sqlCommand.Parameters.AddWithValue("@KhoathiX", blankCertConfigModel.ExamX);
                    sqlCommand.Parameters.AddWithValue("@KhoathiY", blankCertConfigModel.ExamY);
                    sqlCommand.Parameters.AddWithValue("@DantocX", blankCertConfigModel.EthnicX);
                    sqlCommand.Parameters.AddWithValue("@DantocY", blankCertConfigModel.EthnicX);
                    sqlCommand.Parameters.AddWithValue("@DiemthiX", blankCertConfigModel.ScoreX);
                    sqlCommand.Parameters.AddWithValue("@DiemthiY", blankCertConfigModel.ScoreY);
                    sqlCommand.Parameters.AddWithValue("@LoaiId", blankCertConfigModel.BlankCertTypeId);
                    sqlCommand.Parameters.AddWithValue("@IsActive", blankCertConfigModel.IsActive);
                    sqlCommand.Parameters.AddWithValue("@CreatedAt", blankCertConfigModel.CreatedAt);
                    sqlCommand.Parameters.AddWithValue("@Ghichu", blankCertConfigModel.Note);

                    int insertedId = (int)sqlCommand.ExecuteScalar();
                    if(blankCertConfigModel.IsActive == true)
                    {
                        sqlCommand = new SqlCommand(updateQueryString, conn, sqlTransaction);
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.Parameters.AddWithValue("@LoaiId", blankCertConfigModel.BlankCertTypeId);
                        sqlCommand.Parameters.AddWithValue("@Id", insertedId);
                        sqlCommand.ExecuteNonQuery();
                    }

                    sqlTransaction.Commit();
                }
                catch(Exception ex)
                {
                    sqlTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }

            return 1;
        }

        public List<BlankCertConfigModel> GetAll()
        {
            List<BlankCertConfigModel> blankCertConfigModels = new List<BlankCertConfigModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Name as 'Tenloai'
                                        FROM [dbo].[tblThongsophoi] as a
                                        left join [dbo].[tblLoai] as b
                                        on a.LoaiId = b.Id 
                                        where a.IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        BlankCertConfigModel blankCertConfigModel = new BlankCertConfigModel();
                        blankCertConfigModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        blankCertConfigModel.SchoolX = int.Parse(sqlDataReader["TruongX"].ToString());
                        blankCertConfigModel.SchoolY = int.Parse(sqlDataReader["TruongY"].ToString());
                        blankCertConfigModel.FullNameX = int.Parse(sqlDataReader["HovatenX"].ToString());
                        blankCertConfigModel.FullNameY = int.Parse(sqlDataReader["HovatenY"].ToString());
                        blankCertConfigModel.GenderX = int.Parse(sqlDataReader["GioitinhX"].ToString());
                        blankCertConfigModel.GenderY = int.Parse(sqlDataReader["GioitinhY"].ToString());
                        blankCertConfigModel.DobX = int.Parse(sqlDataReader["NgaysinhX"].ToString());
                        blankCertConfigModel.DobY = int.Parse(sqlDataReader["NgaysinhY"].ToString());
                        blankCertConfigModel.MajorX = int.Parse(sqlDataReader["NganhdaotaoX"].ToString());
                        blankCertConfigModel.MajorY = int.Parse(sqlDataReader["NgaydaotaoY"].ToString());
                        blankCertConfigModel.RankingX = int.Parse(sqlDataReader["XeploaiX"].ToString());
                        blankCertConfigModel.RankingY = int.Parse(sqlDataReader["XeploaiY"].ToString());
                        blankCertConfigModel.LearningModeX = int.Parse(sqlDataReader["HinhthucdaotaoX"].ToString());
                        blankCertConfigModel.LearningModeY = int.Parse(sqlDataReader["HinhthucdaotaoY"].ToString());
                        blankCertConfigModel.CreatedDateX = int.Parse(sqlDataReader["NgaytaovanbangX"].ToString());
                        blankCertConfigModel.CreatedDateY = int.Parse(sqlDataReader["NgaytaovanbangY"].ToString());
                        blankCertConfigModel.BornedAddressX = int.Parse(sqlDataReader["NoisinhX"].ToString());
                        blankCertConfigModel.BornedAddressY = int.Parse(sqlDataReader["NoisinhY"].ToString());
                        blankCertConfigModel.SerialX = int.Parse(sqlDataReader["SohieuX"].ToString());
                        blankCertConfigModel.SerialY = int.Parse(sqlDataReader["SohieuY"].ToString());
                        blankCertConfigModel.ReferenceNumberX = int.Parse(sqlDataReader["SovaosoX"].ToString());
                        blankCertConfigModel.ReferenceNumberY = int.Parse(sqlDataReader["SovaosoY"].ToString());
                        blankCertConfigModel.ExamX = int.Parse(sqlDataReader["KhoathiX"].ToString());
                        blankCertConfigModel.ExamY = int.Parse(sqlDataReader["KhoathiY"].ToString());
                        blankCertConfigModel.EthnicX = int.Parse(sqlDataReader["DantocX"].ToString());
                        blankCertConfigModel.EthnicY = int.Parse(sqlDataReader["DantocY"].ToString());
                        blankCertConfigModel.ScoreX = int.Parse(sqlDataReader["DiemthiX"].ToString());
                        blankCertConfigModel.ScoreY = int.Parse(sqlDataReader["DiemthiY"].ToString());
                        blankCertConfigModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        blankCertConfigModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        blankCertConfigModel.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString());
                        blankCertConfigModel.CreatedAt = DateTime.Parse(sqlDataReader["CreatedAt"].ToString());
                        blankCertConfigModel.Note = sqlDataReader["Ghichu"].ToString();
                        blankCertConfigModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());

                        blankCertConfigModels.Add(blankCertConfigModel);
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

            return blankCertConfigModels;
        }

        public BlankCertConfigModel GetSingleByBlankCertType(int blankCertTypeId)
        {
            BlankCertConfigModel blankCertConfigModel = new BlankCertConfigModel();

            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Name as 'Tenloai'
                                        FROM [dbo].[tblThongsophoi] as a
                                        left join [dbo].[tblLoai] as b
                                        on a.LoaiId = b.Id 
                                        where a.IsDeleted = 0 and a.IsActive = 1 and a.LoaiId = @LoaiId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@LoaiId", blankCertTypeId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        blankCertConfigModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        blankCertConfigModel.SchoolX = int.Parse(sqlDataReader["TruongX"].ToString());
                        blankCertConfigModel.SchoolY = int.Parse(sqlDataReader["TruongY"].ToString());
                        blankCertConfigModel.FullNameX = int.Parse(sqlDataReader["HovatenX"].ToString());
                        blankCertConfigModel.FullNameY = int.Parse(sqlDataReader["HovatenY"].ToString());
                        blankCertConfigModel.GenderX = int.Parse(sqlDataReader["GioitinhX"].ToString());
                        blankCertConfigModel.GenderY = int.Parse(sqlDataReader["GioitinhY"].ToString());
                        blankCertConfigModel.DobX = int.Parse(sqlDataReader["NgaysinhX"].ToString());
                        blankCertConfigModel.DobY = int.Parse(sqlDataReader["NgaysinhY"].ToString());
                        blankCertConfigModel.MajorX = int.Parse(sqlDataReader["NganhdaotaoX"].ToString());
                        blankCertConfigModel.MajorY = int.Parse(sqlDataReader["NgaydaotaoY"].ToString());
                        blankCertConfigModel.RankingX = int.Parse(sqlDataReader["XeploaiX"].ToString());
                        blankCertConfigModel.RankingY = int.Parse(sqlDataReader["XeploaiY"].ToString());
                        blankCertConfigModel.LearningModeX = int.Parse(sqlDataReader["HinhthucdaotaoX"].ToString());
                        blankCertConfigModel.LearningModeY = int.Parse(sqlDataReader["HinhthucdaotaoY"].ToString());
                        blankCertConfigModel.CreatedDateX = int.Parse(sqlDataReader["NgaytaovanbangX"].ToString());
                        blankCertConfigModel.CreatedDateY = int.Parse(sqlDataReader["NgaytaovanbangY"].ToString());
                        blankCertConfigModel.BornedAddressX = int.Parse(sqlDataReader["NoisinhX"].ToString());
                        blankCertConfigModel.BornedAddressY = int.Parse(sqlDataReader["NoisinhY"].ToString());
                        blankCertConfigModel.SerialX = int.Parse(sqlDataReader["SohieuX"].ToString());
                        blankCertConfigModel.SerialY = int.Parse(sqlDataReader["SohieuY"].ToString());
                        blankCertConfigModel.ReferenceNumberX = int.Parse(sqlDataReader["SovaosoX"].ToString());
                        blankCertConfigModel.ReferenceNumberY = int.Parse(sqlDataReader["SovaosoY"].ToString());
                        blankCertConfigModel.ExamX = int.Parse(sqlDataReader["KhoathiX"].ToString());
                        blankCertConfigModel.ExamY = int.Parse(sqlDataReader["KhoathiY"].ToString());
                        blankCertConfigModel.EthnicX = int.Parse(sqlDataReader["DantocX"].ToString());
                        blankCertConfigModel.EthnicY = int.Parse(sqlDataReader["DantocY"].ToString());
                        blankCertConfigModel.ScoreX = int.Parse(sqlDataReader["DiemthiX"].ToString());
                        blankCertConfigModel.ScoreY = int.Parse(sqlDataReader["DiemthiY"].ToString());
                        blankCertConfigModel.BlankCertTypeId = int.Parse(sqlDataReader["LoaiId"].ToString());
                        blankCertConfigModel.BlankCertTypeName = sqlDataReader["Tenloai"].ToString();
                        blankCertConfigModel.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString());
                        blankCertConfigModel.CreatedAt = DateTime.Parse(sqlDataReader["CreatedAt"].ToString());
                        blankCertConfigModel.Note = sqlDataReader["Ghichu"].ToString();
                        blankCertConfigModel.IsDeleted = bool.Parse(sqlDataReader["IsDeleted"].ToString());
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

            return blankCertConfigModel;
        }
    }
}
