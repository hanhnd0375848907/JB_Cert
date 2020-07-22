using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDepartmentOfEducationAndTrainingService
    {
        DepartmentOfEducationAndTrainingModel GetInfor();

        int UpdateInfor(DepartmentOfEducationAndTrainingModel departmentOfEducationAndTrainingModel);
    }
    public class DepartmentOfEducationAndTrainingService : IDepartmentOfEducationAndTrainingService
    {
        IDepartmentOfEducationAndTrainingRepository departmentOfEducationAndTrainingRepository;
        public DepartmentOfEducationAndTrainingService()
        {
            departmentOfEducationAndTrainingRepository = new DepartmentOfEducationAndTrainingRepository();
        }
        public DepartmentOfEducationAndTrainingModel GetInfor()
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

        public int UpdateInfor(DepartmentOfEducationAndTrainingModel departmentOfEducationAndTrainingModel)
        {
            try
            {
                return departmentOfEducationAndTrainingRepository.UpdateInfor(departmentOfEducationAndTrainingModel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
