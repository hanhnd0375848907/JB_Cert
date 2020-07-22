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
    }
    public class VillageRepository : IVillageRepository
    {
        SqlConnection conn;

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
    }
}
