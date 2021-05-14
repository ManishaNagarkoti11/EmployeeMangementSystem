using EmployeeMangementSystem.Models;
using EmployeeMangementSystem.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Repositories
{
    public interface IDepartmentRepository
    {
        void AddDepartment(Department department);
        List<DepartmentDto> ShowResult();
        List<EmployeeCandidateHourDto> Show();
        List<CandidateEmployeeHour1Dto> CandidateEmployeeHourDetails();

        
       
    }
}
