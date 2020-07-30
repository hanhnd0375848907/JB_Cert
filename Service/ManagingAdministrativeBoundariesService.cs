using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IManagingAdministrativeBoundariesService
    {
        List<TotalVillageInTownModel> GetTotalVillageByTown();

        List<TotalVillageInTownModel> GetTotalVillageByTownName(string townName);

        List<TownModel> GetManyTownByName(string townName);

        List<TownModel> GetAllTown();

        List<VillageModel> GetAllVillage();

        int AddTown(TownModel townModel);

        TownModel GetSingleTownByTownId(int townId);

        int UpdateTown(TownModel townModel);

        List<VillageModel> GetManyVillageByVillageNameAndTownId(string villageName, int townId);

        int AddVillage(VillageModel villageModel);

        VillageModel GetSingleVillageById(int villageId);

        int UpdateVillage(VillageModel villageModel);

        int DeleteManyVillage(List<int> villageIds);

        List<VillageModel> GetAllCanDeleteVillage();

        List<TownModel> GetAllCanNotDeleteTown();

        int DeleteManyTown(List<int> townIds);

    }
    public class ManagingAdministrativeBoundariesService : IManagingAdministrativeBoundariesService
    {
        ITownRepository townRepository;
        IVillageRepository villageRepository;

        public ManagingAdministrativeBoundariesService()
        {
            townRepository = new TownRepository();
            villageRepository = new VillageRepository();
        }

        public List<TotalVillageInTownModel> GetTotalVillageByTown()
        {
            try
            {
                return townRepository.GetTotalVillageByTown();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<VillageModel> GetAllVillage()
        {
            throw new NotImplementedException();
        }

        public List<TotalVillageInTownModel> GetTotalVillageByTownName(string townName)
        {
            try
            {
                return townRepository.GetTotalVillageByTownName(townName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TownModel> GetManyTownByName(string townName)
        {
            try
            {
                return townRepository.GetManyTownByName(townName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddTown(TownModel townModel)
        {
            try
            {
                return townRepository.AddTown(townModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TownModel GetSingleTownByTownId(int townId)
        {
            try
            {
                return townRepository.GetSingleTownByTownId(townId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateTown(TownModel townModel)
        {
            try
            {
                return townRepository.UpdateTown(townModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TownModel> GetAllTown()
        {
            try
            {
                return townRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VillageModel> GetManyVillageByVillageNameAndTownId(string villageName, int townId)
        {
            try
            {
                return villageRepository.GetManyVillageByVillageNameAndTownId(villageName, townId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddVillage(VillageModel villageModel)
        {
            try
            {
                return villageRepository.AddVillage(villageModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VillageModel GetSingleVillageById(int villageId)
        {
            try
            {
                return villageRepository.GetSingleVillageById(villageId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateVillage(VillageModel villageModel)
        {
            try
            {
                return villageRepository.UpdateVillage(villageModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManyVillage(List<int> villageIds)
        {
            try
            {
                int result = 0;
                foreach(var villageId in villageIds)
                {
                    result += villageRepository.DeleteVillage(villageId);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<VillageModel> GetAllCanDeleteVillage()
        {
            try
            {
                return villageRepository.GetAllCanDeleteVillage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TownModel> GetAllCanNotDeleteTown()
        {
            try
            {
                return townRepository.GetAllCanNotDeleteTown();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManyTown(List<int> townIds)
        {
            try
            {
                int result = 0;
                foreach(int townId in townIds)
                {
                    result += townRepository.DeleteTown(townId);
                    result += villageRepository.DeleteVillageByTownId(townId);

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
