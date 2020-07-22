using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IManagingBlankCertTypeService
    {
        List<BlankCertTypeModel> GetAllBlankCertType();

        int AddBlankCertType(BlankCertTypeModel blankCertTypeModel);

        BlankCertTypeModel GetSingleBlankCertTypeById(int blankCertTypeId);

        int UpdateBlanCertType(BlankCertTypeModel blankCertTypeModel);

        int DeleteBlankCertType(int blankCertTypeId);

        int DeleteManyBlankCertType(List<int> blankCertTypeIds);

    }
    public class ManagingBlankCertTypeService : IManagingBlankCertTypeService
    {
        IBlankCertTypeRepository blankCertTypeRepository;
        public ManagingBlankCertTypeService()
        {
            blankCertTypeRepository = new BlankCertTypeRepository();
        }

        public int AddBlankCertType(BlankCertTypeModel blankCertTypeModel)
        {
            try
            {
                return blankCertTypeRepository.AddBlankCertType(blankCertTypeModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteBlankCertType(int blankCertTypeId)
        {
            try
            {
                return blankCertTypeRepository.DeleteBlankCertType(blankCertTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManyBlankCertType(List<int> blankCertTypeIds)
        {
            try
            {
                int result = 0;
                foreach(int blankCertTypeId in blankCertTypeIds)
                {
                    result += blankCertTypeRepository.DeleteBlankCertType(blankCertTypeId);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BlankCertTypeModel> GetAllBlankCertType()
        {
            try
            {
                return blankCertTypeRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public BlankCertTypeModel GetSingleBlankCertTypeById(int blankCertTypeId)
        {
            try
            {
                return blankCertTypeRepository.GetSingleBlankCertTypeById(blankCertTypeId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateBlanCertType(BlankCertTypeModel blankCertTypeModel)
        {
            try
            {
                return blankCertTypeRepository.UpdateBlanCertType(blankCertTypeModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
