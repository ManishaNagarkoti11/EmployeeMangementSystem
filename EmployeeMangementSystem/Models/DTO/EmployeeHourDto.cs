using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Models.DTO
{
    public class EmployeeHourDto
    {
        public Employee Employee { get; set; }
        public HourLogDetail HourLog { get; set; }
    }
}
