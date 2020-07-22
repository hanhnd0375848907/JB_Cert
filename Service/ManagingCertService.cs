using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IManagingCertService
    {
        List<CertModel> GetAllCert();

        int AddManyCerts(List<BlankCertModel> blankCertModels, List<StudentModel> studentModels, string certName);

        List<CertModel> GetAllNotPrintedCert();

        CertModel GetSingleCertById(int certId);

        int DeleteCert(int certId);

        List<CertModel> GetAllNotPrintedCertBySchool(int schoolId);

        List<CertModel> SearchCert(string studentName, int schoolId, string serial, string referenceNumber);

        int DeleteManyCert(List<int> certIds);
    }
    public class ManagingCertService : IManagingCertService
    {
        ICertRepository certRepository;

        public ManagingCertService()
        {
            certRepository = new CertRepository();
        }

        public int AddManyCerts(List<BlankCertModel> blankCertModels, List<StudentModel> studentModels, string certName)
        {
            try
            {
                return certRepository.AddManyCerts(blankCertModels, studentModels, certName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteCert(int certId)
        {
            try
            {
                return certRepository.DeleteCert(certId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManyCert(List<int> certIds)
        {
            try
            {
                int result = 0;
                foreach(int certId in certIds)
                {
                    result += certRepository.DeleteCert(certId);
                }

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<CertModel> GetAllCert()
        {
            try
            {
                return certRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CertModel> GetAllNotPrintedCert()
        {
            try
            {
                return certRepository.GetAllNotPrintedCert();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<CertModel> GetAllNotPrintedCertBySchool(int schoolId)
        {
            try
            {
                return certRepository.GetAllNotPrintedCertBySchool(schoolId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CertModel GetSingleCertById(int certId)
        {
            try
            {
                return certRepository.GetSingleCertById(certId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CertModel> SearchCert(string studentName, int schoolId, string serial, string referenceNumber)
        {
            try
            {
                return certRepository.SearchCert(studentName, schoolId, serial, referenceNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
