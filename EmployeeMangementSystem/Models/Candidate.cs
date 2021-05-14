using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public bool IsActive { get; set; }
        public int StatusId { get; set; }

        public DateTime StartTime { get; set; }
        public virtual ICollection<HourLogDetail>HourLogDetails { get; set; }
        
       
        

    }
}
