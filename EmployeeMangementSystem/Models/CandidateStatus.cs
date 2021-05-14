using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Models
{
    public class CandidateStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Candidate Candidate { get; set; }
    }
}
