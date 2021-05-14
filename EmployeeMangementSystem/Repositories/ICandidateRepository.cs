using EmployeeMangementSystem.Models;
using EmployeeMangementSystem.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Repositories
{
   public interface ICandidateRepository
    {
        void addCandidate(CandidateDto candidate);
        List<CandidateDto> ShowAllCandidates();
        List<MixCandidateDto> ShowAllDetails();

        void updateCandidateStatus();
    }
   
}
