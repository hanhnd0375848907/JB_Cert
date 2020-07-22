using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IManagingSchoolService
    {
        List<SchoolModel> GetAllSchool();

        List<TownModel> GetAllTown();

        List<VillageModel> GetAllVillage();

        List<VillageModel> GetAllVillageByTownId(int townId);

        DepartmentOfEducationAndTrainingModel GetInforOfDoEaT();

        int AddSchool(SchoolModel schoolModel);

        int UpdateSchool(SchoolModel schoolModel);

        SchoolModel GetSingleSchoolById(int schoolId);

        int DeleteSchool(int schoolId);

        int DeleteManySchool(List<int> schoolIds);

        List<SchoolModel> GetAllSchoolByBlankCertTypeId(int blankCertTypeId);

        List<ExamModel> GetAllExam();

        List<ExamModel> GetAllExamBySchool(int schoolId);

        ExamModel GetSingleExamById(int examId);

        int AddExam(ExamModel examModel);

        int UpdateExam(ExamModel examModel);

        int DeleteExam(int examId);

        int DeleteManyExam(List<int> examIds);

        List<SchoolModel> SearchSchool(string schoolName, int townId, int villageId, string phoneNumber);
    }
    public class ManagingSchoolService : IManagingSchoolService
    {
        ISchoolRepository schoolRepository;
        ITownRepository townRepository;
        IVillageRepository villageRepository;
        IDepartmentOfEducationAndTrainingRepository departmentOfEducationAndTrainingRepository;
        IExamRepository examRepository;

        public ManagingSchoolService()
        {
            schoolRepository = new SchoolRepository();
            townRepository = new TownRepository();
            villageRepository = new VillageRepository();
            departmentOfEducationAndTrainingRepository = new DepartmentOfEducationAndTrainingRepository();
            examRepository = new ExamRepository();
        }

        public int AddSchool(SchoolModel schoolModel)
        {
            try
            {
                return schoolRepository.AddSchool(schoolModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteSchool(int schoolId)
        {
            try
            {
                return schoolRepository.DeleteSchool(schoolId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ExamModel> GetAllExamBySchool(int schoolId)
        {
            try
            {
                return examRepository.GetBySchool(schoolId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ExamModel> GetAllExam()
        {
            try
            {
                return examRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SchoolModel> GetAllSchool()
        {
            try
            {
                return schoolRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<SchoolModel> GetAllSchoolByBlankCertTypeId(int blankCertTypeId)
        {
            try
            {
                return schoolRepository.GetAllSchoolByBlankCertTypeId(blankCertTypeId);
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<VillageModel> GetAllVillage()
        {
            try
            {
                return villageRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<VillageModel> GetAllVillageByTownId(int townId)
        {
            try
            {
                return villageRepository.GetAllVillageByTownId(townId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DepartmentOfEducationAndTrainingModel GetInforOfDoEaT()
        {
            try
            {
                return departmentOfEducationAndTrainingRepository.GetInfo();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ExamModel GetSingleExamById(int examId)
        {
            try
            {
                return examRepository.GetSingleById(examId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SchoolModel GetSingleSchoolById(int schoolId)
        {
            try
            {
                return schoolRepository.GetSingleSchoolById(schoolId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateSchool(SchoolModel schoolModel)
        {
            try
            {
                return schoolRepository.UpdateSchool(schoolModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int AddExam(ExamModel examModel)
        {
            try
            {
                return examRepository.AddExam(examModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateExam(ExamModel examModel)
        {
            try
            {
                return examRepository.UpdateExam(examModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteExam(int examId)
        {
            try
            {
                return examRepository.DeleteExam(examId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SchoolModel> SearchSchool(string schoolName, int townId, int villageId, string phoneNumber)
        {
            try
            {
                return schoolRepository.SearchSchool(schoolName, townId, villageId, phoneNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManySchool(List<int> schoolIds)
        {
            try
            {
                int result = 0;
                foreach(int schoolId in schoolIds)
                {
                    result += schoolRepository.DeleteSchool(schoolId);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManyExam(List<int> examIds)
        {
            try
            {
                int result = 0;
                foreach (int examId in examIds)
                {
                    result += examRepository.DeleteExam(examId);
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
