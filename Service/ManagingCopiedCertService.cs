using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IManagingCopiedCertService
    {
        List<CopiedCertModel> GetAllCopiedCert();

        int AddManyCopiedCert(List<BlankCertModel> blankCertModels, List<StudentModel> studentModels, string certName);
    }
    public class ManagingCopiedCertService : IManagingCopiedCertService
    {
        ICopiedCertRepository copiedCertRepository;
        ICertRepository certRepository;
        public ManagingCopiedCertService()
        {
            copiedCertRepository = new CopiedCertRepository();
            certRepository = new CertRepository();
        }

        public int AddManyCopiedCert(List<BlankCertModel> blankCertModels, List<StudentModel> studentModels, string certName)
        {
            try
            {
                int result = copiedCertRepository.AddManyCopiedCerts(blankCertModels, studentModels, certName);

                return result = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CopiedCertModel> GetAllCopiedCert()
        {
            try
            {
                return copiedCertRepository.GetAllCopiedCert();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
