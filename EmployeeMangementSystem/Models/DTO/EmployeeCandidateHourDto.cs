using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Models.DTO
{
    public class EmployeeCandidateHourDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public List<CandidateHourDto> CandidateHours { get; set; }
        public double? TotalHour { get; set; }
    }
}
