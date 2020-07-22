using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IManagingBlankCertConfigService
    {
        List<BlankCertConfigModel> GetAllBlankCertConfig();

        int AddBlankCertConfig(BlankCertConfigModel blankCertConfigModel);

        BlankCertConfigModel GetSingleByBlankCertType(int blankCertTypeId);
    }
    public class ManagingBlankCertConfigService : IManagingBlankCertConfigService
    {
        IBlankCertConfigRepository blankCertConfigRepository;
        public ManagingBlankCertConfigService()
        {
            blankCertConfigRepository = new BlankCertConfigRepository();
        }

        public int AddBlankCertConfig(BlankCertConfigModel blankCertConfigModel)
        {
            try
            {
                return blankCertConfigRepository.Add(blankCertConfigModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<BlankCertConfigModel> GetAllBlankCertConfig()
        {
            try
            {
                return blankCertConfigRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BlankCertConfigModel GetSingleByBlankCertType(int blankCertTypeId)
        {
            try
            {
                return blankCertConfigRepository.GetSingleByBlankCertType(blankCertTypeId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
