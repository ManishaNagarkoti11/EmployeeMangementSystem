using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Models.DTO
{
    public class CandidateEmployeeHour1Dto
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public List<EmployeeHour1Dto> Employee { get; set; }
        public double? TotalHour { get; set; }

    }
}
