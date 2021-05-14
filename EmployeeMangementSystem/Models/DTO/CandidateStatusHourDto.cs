using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Models.DTO
{
    public class CandidateStatusHourDto
    {
        public Candidate candidate { get; set; }
        public HourLogDetail hourLogDetail { get; set; }
        //public CandidateStatus candidateStatus { get; set; }

    }
}
