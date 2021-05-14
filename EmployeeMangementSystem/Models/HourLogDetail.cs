
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Models
{
    public class HourLogDetail
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CandidateId { get; set; }
        public double? Hour { get; set; }
        public DateTime Date { get; set; }

        //[JsonIgnore]
        public virtual Employee Employee { get; set; }
        public virtual Candidate Candidate { get; set; }
    

    }
}
