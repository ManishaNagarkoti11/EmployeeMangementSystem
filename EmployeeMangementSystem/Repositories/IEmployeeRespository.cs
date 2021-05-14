using EmployeeMangementSystem.Models;
using EmployeeMangementSystem.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Repositories
{
    public interface IEmployeeRespository
    {
        void addEmployee(Employee emlpoyee);
        List<EmployeeDto> showEmployees();
        List<Employee> ShowAccordingAddress(string address);
        void addAssignedEvent(AssignedEvent events );
        List<AssignedEvent> ShowAssignedEvent();
        void addHourLogDetail(HourLogDetail details);
        List<HourLogDetail> ShowHourLogDetail();
        List<EmployeeDto> ShowTask2();
        List<Employee> AvailableEmployees();
        void UpdateStatus();
        


    }
}
