using EmployeeMangementSystem.Models;
using EmployeeMangementSystem.Models.DTO;
using EmployeeMangementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class DepartmentController: ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentController( IDepartmentRepository departmentRep)
        {
            
            departmentRepository = departmentRep;
        }
         [HttpPost]
         [Route("/api/AddDepartment")]
        public void AddDepartment(Department department)
        {
            departmentRepository.AddDepartment(department);
        }

        [HttpGet]
        [Route("/api/ShowResult")]
      public List<DepartmentDto> ShowResult()
        {
            var result = departmentRepository.ShowResult();
            return result;
        }

        //List of candidate whos is assigned to particular employee with hourLogDetails

        [HttpGet]
        [Route("/api/ShowCandidateNameAssignedToParticularEmployee")]
        public List<EmployeeCandidateHourDto> Show()
        {
            var result = departmentRepository.Show();
            return result;
        }
        [HttpGet]
        [Route("/api/ShowCandidateEmployeeHourDetails")]
        public List<CandidateEmployeeHour1Dto> CandidateEmployeeHourDetails()
        {
            var result = departmentRepository.CandidateEmployeeHourDetails();
            return result;
        }

        public void DepartmentChange(Candidate candidate)
        {
             
        }
        
    }
}
