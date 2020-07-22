using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IManagingBlankCertService
    {
        List<BlankCertModel> GetAllBlankCert();

        string GetBlankCertImage(int blankCertId);

        List<BlankCertModel> GetAllAvailableBlankCert();

        BlankCertModel GetSingleById(int certId);

        int Update(BlankCertModel blankCertModel);

        int Delete(int certID);

        int Add(string serial, string createdById, string image, int blankCertTypeId);

        int DeleteManyBlankCert(List<int> blankCertIds);

        List<BlankCertModel> SearchAvailableBlankCertBySerial(string serial);

        List<BlankCertModel> SearchAvailableBlankCertBySerialAndBlankCertType(string serial, int blankCertTypeId);

        List<BlankCertTypeModel> GetAllBlankCertType();

        List<BlankCertModel> SearchBlankCertFormForAddingCert(string serial, int blankCertTypeId);

        List<BlankCertModel> SearchBlankCert(string serial, int blankCertTypeId, int status);
    }


    public class ManagingBlankCertService : IManagingBlankCertService
    {
        IBlankCertRepository blankCertRepository;
        IBlankCertTypeRepository blankCertTypeRepository;
        public ManagingBlankCertService()
        {
            blankCertRepository = new BlankCertRepository();
            blankCertTypeRepository = new BlankCertTypeRepository();
        }

        public int Add(string serial, string createdById, string image, int blankCertTypeId)
        {
            try
            {
                return blankCertRepository.Add(serial, createdById, image, blankCertTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int certID)
        {
            try
            {
                return blankCertRepository.Delete(certID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManyBlankCert(List<int> blankCertIds)
        {
            try
            {
                int result = 0;
                foreach(int blankCertId in blankCertIds)
                {
                    result += blankCertRepository.Delete(blankCertId);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BlankCertModel> GetAllAvailableBlankCert()
        {
            try
            {
                return blankCertRepository.GetAllAvailableBlankCert();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BlankCertModel> GetAllBlankCert()
        {
            try
            {
                return blankCertRepository.GetAll();
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

        public string GetBlankCertImage(int blankCertId)
        {
            try
            {
                return blankCertRepository.GetBlankCertImage(blankCertId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public BlankCertModel GetSingleById(int certId)
        {
            try
            {
                return blankCertRepository.GetSingleById(certId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BlankCertModel> SearchAvailableBlankCertBySerial(string serial)
        {
            try
            {
                return blankCertRepository.SearchAvailableBlankCertBySerial(serial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BlankCertModel> SearchAvailableBlankCertBySerialAndBlankCertType(string serial, int blankCertTypeId)
        {
            try
            {
                return blankCertRepository.SearchAvailableBlankCertBySerialAndBlankCertType(serial, blankCertTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BlankCertModel> SearchBlankCert(string serial, int blankCertTypeId, int status)
        {
            try
            {
                return blankCertRepository.SearchBlankCert(serial, blankCertTypeId, status);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BlankCertModel> SearchBlankCertFormForAddingCert(string serial, int blankCertTypeId)
        {
            try
            {
                return blankCertRepository.SearchBlankCertFormForAddingCert(serial, blankCertTypeId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Update(BlankCertModel blankCertModel)
        {
            try
            {
                return blankCertRepository.Update(blankCertModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
