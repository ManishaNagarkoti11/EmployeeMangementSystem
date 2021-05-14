using EmployeeMangementSystem.Models;
using EmployeeMangementSystem.Models.DTO;
using EmployeeMangementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateRepository candidateRepository;
     
        public CandidateController(ICandidateRepository canRepo)
        {
           
            candidateRepository = canRepo;
        }

        [HttpPost]
        [Route("/api/AddCandidate")]
        public void AddCandidate(CandidateDto candidate)
        {
            candidateRepository.addCandidate(candidate);
         }

        [HttpGet]
        [Route("/api/ShowAllCandidates")]
        public List<CandidateDto> ShowAllCandidates()
        {
            var result=candidateRepository.ShowAllCandidates();
            return result;
        }

        [HttpGet]
        [Route("/api/ShowAllDetails")]
        public List<MixCandidateDto> ShowAllDetails()
        {
            var result=candidateRepository.ShowAllDetails();
            return result;
        }

        [HttpGet]
        [Route("/api/UpdateStatus")]
        public void updateCandidateStatus()
        {
            candidateRepository.updateCandidateStatus();
        }
    }
   

     
}
