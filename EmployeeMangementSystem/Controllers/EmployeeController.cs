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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRespository employeeRepository;
        public EmployeeController(IEmployeeRespository empRepo)
        {
            employeeRepository = empRepo;
        }

        // For Employee Table
        [HttpPost]
        [Route("/api/AddEmployee")]
        public void AddEmployee(Employee employee)
        {
            employeeRepository.addEmployee(employee);
        }
        [HttpGet]
        [Route("/api/ViewEmployeeDetail")]
        public List<EmployeeDto> ViewEmployeeDetail()
        {
           var result= employeeRepository.showEmployees();
            return result;
        }


        [HttpGet]
        [Route("/api/Show")]
        public List<Employee> Show(string address)
        {
           var result= employeeRepository.ShowAccordingAddress(address);
            return result;
            //ctrl+k+c to  comment    select  area
            //var a = from employee in _context.Employees
            //        where employee.Address == address
            //        select employee.Address;

        }

        //For AssignedDepartment Table

        [HttpPost]
        [Route("/api/assignDepartment")]
        public void assignDepartment(AssignedEvent events)
        {
           
            employeeRepository.addAssignedEvent(events);
        }

        [HttpGet]
        [Route("/api/ShowAssignedEvent")]
        public List<AssignedEvent> ShowAssignedEvent() {
            var result = employeeRepository.ShowAssignedEvent();
            return result;
        }

        //For HourLogDetail Table
        [HttpPost]
        [Route("/api/HourLogDetail")]
         public void HourLogDetail(HourLogDetail details)
        {
            
            employeeRepository.addHourLogDetail(details);
            
            
        }


        [HttpGet]
        [Route("/api/ShowHourLogDetail")]
        public List<HourLogDetail> ShowHourLogDetail()
        {
            var result = employeeRepository.ShowHourLogDetail();
            return result;
        }

        //API which show details of all employess where department=IT using DTO

        [HttpGet]
        [Route("/api/ShowTask2")]
        public List<EmployeeDto> ShowTask2()
        {
            var result = employeeRepository.ShowTask2();
            return result;

        }
        [HttpGet]
        [Route("/api/AvailableEmployees")]
        public List<Employee> AvailableEmployees()
        {
            employeeRepository.UpdateStatus();
            List<Employee> result = employeeRepository.AvailableEmployees();
            return result;
        }
      
        [HttpPost]
        [Route("/api/employeestatus")]

        public void UpdateStatus()
        {
            employeeRepository.UpdateStatus();
        }
    }
}
