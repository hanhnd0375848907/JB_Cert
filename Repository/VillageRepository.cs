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
    public interface IVillageRepository
    {
        List<VillageModel> GetAll();

        List<VillageModel> GetAllVillageByTownId(int townId);

        List<VillageModel> GetManyVillageByVillageNameAndTownId(string villageName, int townId);

        int AddVillage(VillageModel villageModel);

        VillageModel GetSingleVillageById(int villageId);

        int UpdateVillage(VillageModel villageModel);

        int DeleteVillage(int villageId);

        List<VillageModel> GetAllCanDeleteVillage();

        int DeleteVillageByTownId(int townId);
    }
    public class VillageRepository : IVillageRepository
    {
        SqlConnection conn;

        public int AddVillage(VillageModel villageModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"INSERT INTO [dbo].[tblXa]
                                            ([HuyenId]
                                            ,[Ten]
                                            ,[Diachi]
                                            ,[Dienthoai]
                                            ,[Fax]
                                            ,[Ghichu]
                                            ,[IsDeleted])
                                        VALUES
                                            (@HuyenId, @Ten, @Diachi, @Dienthoai, @Fax, @Ghichu, 0)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@HuyenId", villageModel.TownId);
                sqlCommand.Parameters.AddWithValue("@Ten", villageModel.VillageName);
                sqlCommand.Parameters.AddWithValue("@Diachi", villageModel.Address);
                sqlCommand.Parameters.AddWithValue("@Dienthoai", villageModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Fax", villageModel.Fax);
                sqlCommand.Parameters.AddWithValue("@Ghichu", villageModel.Note);
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

        public int DeleteVillage(int villageId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblXa]
                                       SET IsDeleted = 1
                                     WHERE Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", villageId);
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

        public int DeleteVillageByTownId(int townId)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblXa]
                                       SET IsDeleted = 1
                                     WHERE HuyenId = @HuyenId";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@HuyenId", townId);
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

        public List<VillageModel> GetAll()
        {
            List<VillageModel> villageModels = new List<VillageModel>();
            using(conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Ten as 'Tenhuyen'
                                      FROM [jb_cert].[dbo].[tblXa] as a
                                      left join [dbo].[tblHuyen] as b
                                      on a.HuyenId = b.id
                                      where a.IsDeleted = 0";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        VillageModel villageModel = new VillageModel();
                        villageModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        villageModel.TownId = int.Parse(sqlDataReader["HuyenId"].ToString());
                        villageModel.TownName = sqlDataReader["Tenhuyen"].ToString();
                        villageModel.VillageName = sqlDataReader["Ten"].ToString();
                        villageModel.Address = sqlDataReader["Diachi"].ToString();
                        villageModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        villageModel.Fax = sqlDataReader["Fax"].ToString();
                        villageModel.Note = sqlDataReader["Ghichu"].ToString();
                        villageModel.IsDeleted = false;

                        villageModels.Add(villageModel);
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

            return villageModels;
        }

        public List<VillageModel> GetAllCanDeleteVillage()
        {
            List<VillageModel> villageModels = new List<VillageModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.id from [dbo].[tblXa] as a
                                        where a.id not in (select b.XaId from tblTruong as b where b.IsDeleted = 0) and a.IsDeleted = 0 ";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        VillageModel villageModel = new VillageModel();
                        villageModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        villageModels.Add(villageModel);
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

            return villageModels;
        }

        public List<VillageModel> GetAllVillageByTownId(int townId)
        {
            List<VillageModel> villageModels = new List<VillageModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Ten as 'Tenhuyen'
                                      FROM [jb_cert].[dbo].[tblXa] as a
                                      left join [dbo].[tblHuyen] as b
                                      on a.HuyenId = b.id
                                      where a.IsDeleted = 0 
                                        and (@HuyenId = -1 or a.HuyenId = @HuyenId)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@HuyenId", townId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        VillageModel villageModel = new VillageModel();
                        villageModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        villageModel.TownId = int.Parse(sqlDataReader["HuyenId"].ToString());
                        villageModel.TownName = sqlDataReader["Tenhuyen"].ToString();
                        villageModel.VillageName = sqlDataReader["Ten"].ToString();
                        villageModel.Address = sqlDataReader["Diachi"].ToString();
                        villageModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        villageModel.Fax = sqlDataReader["Fax"].ToString();
                        villageModel.Note = sqlDataReader["Ghichu"].ToString();
                        villageModel.IsDeleted = false;

                        villageModels.Add(villageModel);
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

            return villageModels;
        }

        public List<VillageModel> GetManyVillageByVillageNameAndTownId(string villageName, int townId)
        {
            List<VillageModel> villageModels = new List<VillageModel>();
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Ten as 'Tenhuyen'
                                      FROM [jb_cert].[dbo].[tblXa] as a
                                      left join [dbo].[tblHuyen] as b
                                      on a.HuyenId = b.id
                                      where a.IsDeleted = 0 and a.Ten like @Ten
                                        and (@HuyenId = -1 or a.HuyenId = @HuyenId)";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@HuyenId", townId);
                sqlCommand.Parameters.AddWithValue("@Ten", "%" +villageName + "%");
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    while (sqlDataReader.Read())
                    {
                        VillageModel villageModel = new VillageModel();
                        villageModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        villageModel.TownId = int.Parse(sqlDataReader["HuyenId"].ToString());
                        villageModel.TownName = sqlDataReader["Tenhuyen"].ToString();
                        villageModel.VillageName = sqlDataReader["Ten"].ToString();
                        villageModel.Address = sqlDataReader["Diachi"].ToString();
                        villageModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        villageModel.Fax = sqlDataReader["Fax"].ToString();
                        villageModel.Note = sqlDataReader["Ghichu"].ToString();
                        villageModel.IsDeleted = false;

                        villageModels.Add(villageModel);
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

            return villageModels;
        }

        public VillageModel GetSingleVillageById(int villageId)
        {
            VillageModel villageModel = new VillageModel();

            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"SELECT a.*, b.Ten as 'Tenhuyen'
                                      FROM [jb_cert].[dbo].[tblXa] as a
                                      left join [dbo].[tblHuyen] as b
                                      on a.HuyenId = b.id
                                      where a.IsDeleted = 0 and a.Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", villageId);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                try
                {
                    if (sqlDataReader.Read())
                    {
                        villageModel.Id = int.Parse(sqlDataReader["Id"].ToString());
                        villageModel.TownId = int.Parse(sqlDataReader["HuyenId"].ToString());
                        villageModel.TownName = sqlDataReader["Tenhuyen"].ToString();
                        villageModel.VillageName = sqlDataReader["Ten"].ToString();
                        villageModel.Address = sqlDataReader["Diachi"].ToString();
                        villageModel.PhoneNumber = sqlDataReader["Dienthoai"].ToString();
                        villageModel.Fax = sqlDataReader["Fax"].ToString();
                        villageModel.Note = sqlDataReader["Ghichu"].ToString();
                        villageModel.IsDeleted = false;
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

            return villageModel;
        }

        public int UpdateVillage(VillageModel villageModel)
        {
            using (conn = JBCertConnection.Instance)
            {
                string queryString = @"UPDATE [dbo].[tblXa]
                                       SET [HuyenId] = @HuyenId
                                          ,[Ten] = @Ten
                                          ,[Diachi] = @Diachi
                                          ,[Dienthoai] = @Dienthoai
                                          ,[Fax] = @Fax
                                          ,[Ghichu] = @Ghichu
                                     WHERE Id = @Id";
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@HuyenId", villageModel.TownId);
                sqlCommand.Parameters.AddWithValue("@Ten", villageModel.VillageName);
                sqlCommand.Parameters.AddWithValue("@Diachi", villageModel.Address);
                sqlCommand.Parameters.AddWithValue("@Dienthoai", villageModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Fax", villageModel.Fax);
                sqlCommand.Parameters.AddWithValue("@Ghichu", villageModel.Note);
                sqlCommand.Parameters.AddWithValue("@Id", villageModel.Id);
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
