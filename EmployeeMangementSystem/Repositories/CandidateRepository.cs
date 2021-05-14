using EmployeeMangementSystem.Models;
using EmployeeMangementSystem.Models.DTO;
using EmployeeMangementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Repositories
{
    public class CandidateRepository:ICandidateRepository
    {
        private readonly ApplicationDbContext _context;
        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void addCandidate(CandidateDto candidate)
        {
            DateTime startTime = DateTime.Now;
            Candidate newCandidate = new Candidate
            {
                Fname = candidate.FirstName,
                Lname = candidate.LastName,
                StartTime = startTime,
                StatusId = (int)CandidateStatusEnum.New
            };
            _context.Candidates.Add(newCandidate);
            _context.SaveChanges();
        }
        public List<CandidateDto> ShowAllCandidates()
        {
            List<CandidateDto> result = (from candidate in _context.Candidates
                                         select new CandidateDto {
                                             FirstName=candidate.Fname,
                                             LastName=candidate.Lname
                                         }).ToList();
            return result;
        }
        public List<MixCandidateDto> ShowAllDetails()
        {

            var check = _context.HourLogDetails.Where(x=>x.Candidate.Fname=="Nirmala").Select(x=>x.Employee.Fname).ToList();
            var result = (from e in _context.Employees
                          join a in _context.AssignedEvents
                          on e.Id equals a.EmployeeId into EmpAssign
                          from emp in EmpAssign
                          join d in _context.Departments
                          on emp.DepartmentId equals d.Id into EmpDepart
                          from empdep in EmpDepart
                          join h in _context.HourLogDetails
                          on emp.EmployeeId equals h.EmployeeId into EmpHour
                          from emphour in EmpHour
                          join c in _context.Candidates
                          on emphour.CandidateId equals c.Id
                          where e.Address == "Dumre" || e.Address == "Palpa"
                          select new MixCandidateDto
                          {
                              Name = e.Fname + " " + e.Lname,
                              DepartmentName = empdep.Name,
                              Salary = empdep.Salary,
                              StartTime = emp.StartDate,
                              CandidateName = c.Fname + " " + c.Lname,
                              Hour = emphour.Hour,
                              Date = emphour.Date


                          }).ToList();
            return result;
        }

        public void updateCandidateStatus()
        {
            DateTime weekAgoDate = DateTime.Now.AddDays(-7);
            DateTime MonthAgoDate = DateTime.Now.AddMonths(-1);
            var data = _context.Candidates.Select(
                x => new CandidateStatusHourDto
                {
                    candidate = x,
                    hourLogDetail = x.HourLogDetails.OrderByDescending(y => y.Date).FirstOrDefault()
                }).ToList();
            var available = data.Where(x => x.hourLogDetail != null && x.hourLogDetail.Date > MonthAgoDate).ToList();
            var lost = data.Except(available).ToList();
            var weekly=data.Where(x => x.hourLogDetail != null && x.hourLogDetail.Date > weekAgoDate).ToList();
            var updated=available.Select(x=> {
                x.candidate.StatusId = (int)CandidateStatusEnum.Available;
                return x.candidate;
            }).ToList();

            updated.AddRange(lost.Select(x =>
            {
                x.candidate.StatusId = (int)CandidateStatusEnum.Lost;
                return x.candidate;
            }).ToList());
            updated.AddRange(weekly.Select(x =>
            {
                x.candidate.StatusId = (int)CandidateStatusEnum.Assigned;
                x.candidate.IsActive = true;
                return x.candidate;
            }).ToList());


            //var update = (from candidate in _context.Candidates
            //              join candidatestatus in _context.CandidateStatus
            //              on candidate.StatusId equals candidatestatus.Id
            //              join hourlog in _context.HourLogDetails
            //              on candidate.Id equals hourlog.CandidateId
            //              //where (hourlog.Date > weekAgoDate)
            //              select new
            //              {
            //                  candidatestatus,
            //                  hourlog
            //              }).Select(x =>{
            //                  if (x.hourlog.Date > weekAgoDate)
            //                         x.candidatestatus.Name = "Assigned";
            //                  else if (x.hourlog.Date < MonthAgoDate)
            //                          x.candidatestatus.Name = "Lost";
            //                  else if (x.hourlog.Date < weekAgoDate)
            //                          x.candidatestatus.Name = "Available";
            //                  else
            //                        x.candidatestatus.Name = "New";
            //              }).ToList();
            //              select canstatus.Select(x => x.Name == "Assigned")

            //              ).ToList();
            _context.Candidates.UpdateRange(updated);
            _context.SaveChanges();
        }

        }
}
