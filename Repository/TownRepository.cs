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

        List<TotalVillageInTownModel> GetTotalVillageByTown();

        List<TotalVillageInTownModel> GetTotalVillageByTownName(string townName);

        List<TownModel> GetManyTownByName(string townName);

        int AddTown(TownModel townModel);

        TownModel GetSingleTownByTownId(int townId);

        int UpdateTown(TownModel townModel);

        List<TownModel> GetAllCanNotDeleteTown();

        int DeleteTown(int townId);

    }
    public class TownRepository : ITownRepository
    {
        SqlConnection conn;

        public int AddTown(TownModel townModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblHuyen]
                                           ([Ten]
                                           ,[Diachi]
                                           ,[Dienthoai]
                                           ,[Fax]
                                           ,[Ghichu]
                                           ,[IsDeleted])
                                     VALUES
                                           (@Ten, @Diachi, @Dienthoai, @Fax, @Ghichu, 0)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Ten", townModel.TownName);
                sqlCommand.Parameters.AddWithValue("@Diachi", townModel.Address);
                sqlCommand.Parameters.AddWithValue("@Dienthoai", townModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Fax", townModel.Fax);
                sqlCommand.Parameters.AddWithValue("@Ghichu", townModel.Note);
                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    return result;
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

        public int DeleteTown(int townId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblHuyen]
                                       SET [IsDeleted] = 1
                                     WHERE Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", townId);
                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    return result;
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

        public List<TownModel> GetAll()
        {
            List<TownModel> townModels = new List<TownModel>();
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT * FROM [jb_cert].[dbo].[tblHuyen]
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
                        townModel.Fax = sqlDataReader["Fax"].ToString();
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

        public List<TownModel> GetAllCanNotDeleteTown()
        {
            List<TownModel> townModels = new List<TownModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.HuyenId from [dbo].[tblXa] as a
                                        where a.id in (select b.XaId from tblTruong as b where b.IsDeleted = 0) and a.IsDeleted = 0 
                                        group by a.HuyenId";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        TownModel townModel = new TownModel();
                        townModel.Id = int.Parse(sqlDataReader["HuyenId"].ToString());

                        townModels.Add(townModel);
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

            return townModels;
        }

        public List<TownModel> GetManyTownByName(string townName)
        {
            List<TownModel> townModels = new List<TownModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT *
                                      FROM [dbo].[tblHuyen]
                                      Where [tblHuyen].[IsDeleted] = 0 and [tblHuyen].[Ten] like @Ten";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Ten", "%" + townName + "%");
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
                        townModel.Fax = sqlDataReader["Fax"].ToString();
                        townModel.Note = sqlDataReader["Ghichu"].ToString();
                        townModel.IsDeleted = false;

                        townModels.Add(townModel);
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

            return townModels;
        }

        public TownModel GetSingleTownByTownId(int townId)
        {
            TownModel townModel = new TownModel();

            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT *
                                      FROM [dbo].[tblHuyen]
                                      Where Id = @Id";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", townId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        townModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        townModel.TownName = sqlDataReader["Ten"].ToString();
                        townModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        townModel.Address = sqlDataReader["Diachi"].ToString();
                        townModel.Fax = sqlDataReader["Fax"].ToString();
                        townModel.Note = sqlDataReader["Ghichu"].ToString();
                        townModel.IsDeleted = false;
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

            return townModel;
        }

        public List<TotalVillageInTownModel> GetTotalVillageByTown()
        {
            List<TotalVillageInTownModel> totalVillageInTownModels = new List<TotalVillageInTownModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.Id, count(a.Id) 'Soluong' FROM [dbo].[tblHuyen] as a
                                        left join [dbo].[tblxa] as b
                                        on a.Id = b.HuyenId
                                        where a.IsDeleted = 0 and b.IsDeleted = 0
                                        group by a.Id";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        TotalVillageInTownModel totalVillageInTownModel = new TotalVillageInTownModel();
                        totalVillageInTownModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        totalVillageInTownModel.NumberOfVillage = int.Parse(sqlDataReader["Soluong"].ToString());
                        totalVillageInTownModels.Add(totalVillageInTownModel);
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

            return totalVillageInTownModels;
        }

        public List<TotalVillageInTownModel> GetTotalVillageByTownName(string townName)
        {
            List<TotalVillageInTownModel> totalVillageInTownModels = new List<TotalVillageInTownModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.Id, count(a.Id) 'Soluong' FROM [dbo].[tblHuyen] as a
                                        left join [dbo].[tblxa] as b
                                        on a.Id = b.HuyenId
                                        where a.IsDeleted = 0 and b.IsDeleted = 0 and a.Ten like @Ten
                                        group by a.Id";
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Ten", "%" + townName + "%");
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        TotalVillageInTownModel totalVillageInTownModel = new TotalVillageInTownModel();
                        totalVillageInTownModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        totalVillageInTownModel.NumberOfVillage = int.Parse(sqlDataReader["Soluong"].ToString());
                        totalVillageInTownModels.Add(totalVillageInTownModel);
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

            return totalVillageInTownModels;
        }

        public int UpdateTown(TownModel townModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblHuyen]
                                       SET [Ten] = @Ten
                                          ,[Diachi] = @Diachi
                                          ,[Dienthoai] = @Dienthoai
                                          ,[Fax] = @Fax
                                          ,[Ghichu] = @Ghichu
                                          ,[IsDeleted] = 0
                                     WHERE Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Ten", townModel.TownName);
                sqlCommand.Parameters.AddWithValue("@Diachi", townModel.Address);
                sqlCommand.Parameters.AddWithValue("@Dienthoai", townModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Fax", townModel.Fax);
                sqlCommand.Parameters.AddWithValue("@Ghichu", townModel.Note);
                sqlCommand.Parameters.AddWithValue("@Id", townModel.Id);
                try
                {
                    int result = sqlCommand.ExecuteNonQuery();
                    return result;
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
