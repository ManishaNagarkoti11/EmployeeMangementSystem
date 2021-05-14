using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Models.DTO
{
    public class   MixCandidateDto
    {
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public int Salary { get; set; }
        public DateTime StartTime { get; set; }
         public string CandidateName { get; set; }
        public double? Hour { get; set; }
        public DateTime Date { get; set; }
       
    }
}
