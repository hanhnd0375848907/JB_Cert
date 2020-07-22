using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IManagingStudentService
    {
        List<StudentModel> GetAllStudent();

        int AddStudent(StudentModel studentModel);

        List<RankingModel> GetAllRanking();

        List<LearningModeModel> GetAllLearningMode();

        List<MajorModel> GetAllMajor();

        List<EthnicModel> GetAllEthnic();

        string GetStudentImage(int studentId);

        StudentModel GetSingleStudentById(int studentId);

        int UpdateStudent(StudentModel studentModel);

        int DeleteStudent(int studentId);

        int DeleteManyStudent(List<int> studentIds);

        List<StudentModel> SearchByNameAndSchool(string studentName, int schoolId);

        List<StudentModel> SearchStudentForAddingCert(string studentName, int schoolId);

        List<StudentModel> SearchStudent(string fullname, int schoolId, string identityNumber, int graduatingYear);

    }
    public class ManagingStudentService : IManagingStudentService
    {
        IStudentRepository studentRepository;
        IRankingRepository rankingRepository;
        ILearningModeRepository learningModeRepository;
        IMajorRepository majorRepository;
        IEthnicRepository ethnicRepository;
        public ManagingStudentService()
        {
            studentRepository = new StudentRepository();
            rankingRepository = new RankingRepository();
            learningModeRepository = new LearningModeRepository();
            majorRepository = new MajorRepository();
            ethnicRepository = new EthnicRepository();
        }

        public int AddStudent(StudentModel studentModel)
        {
            try
            {
                return studentRepository.AddStudent(studentModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteManyStudent(List<int> studentIds)
        {
            try
            {
                int result = 0;
                foreach(int studentId in studentIds)
                {
                    result += studentRepository.DeleteStudent(studentId);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteStudent(int studentId)
        {
            try
            {
                return studentRepository.DeleteStudent(studentId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<EthnicModel> GetAllEthnic()
        {
            try
            {
                return ethnicRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<LearningModeModel> GetAllLearningMode()
        {
            try
            {
                return learningModeRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<MajorModel> GetAllMajor()
        {
            try
            {
                return majorRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<RankingModel> GetAllRanking()
        {
            try
            {
                return rankingRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentModel> GetAllStudent()
        {
            try
            {
                return studentRepository.GetAll();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public StudentModel GetSingleStudentById(int studentId)
        {
            try
            {
                return studentRepository.GetSingleStudentById(studentId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string GetStudentImage(int studentId)
        {
            try
            {
                return studentRepository.GetImage(studentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentModel> SearchByNameAndSchool(string studentName, int schoolId)
        {
            try
            {
                if (schoolId == -1)
                {
                    return studentRepository.SearchByName(studentName);
                }
                else
                {
                    return studentRepository.SearchByNameAndSchool(studentName, schoolId);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentModel> SearchStudent(string fullname, int schoolId, string identityNumber, int graduatingYear)
        {
            try
            {
                return studentRepository.SearchStudent(fullname, schoolId, identityNumber, graduatingYear);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentModel> SearchStudentForAddingCert(string studentName, int schoolId)
        {
            try
            {
                return studentRepository.SearchStudentForAddingCert(studentName, schoolId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateStudent(StudentModel studentModel)
        {
            try
            {
                return studentRepository.UpdateStudent(studentModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
