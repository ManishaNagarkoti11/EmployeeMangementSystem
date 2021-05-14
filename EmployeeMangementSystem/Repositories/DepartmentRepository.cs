using EmployeeMangementSystem.Models;
using EmployeeMangementSystem.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Repositories
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) {
            _context = context;
        }

        public void AddDepartment(Department department)
        {
           
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
        public List<DepartmentDto> ShowResult()
        {
            var result = (from e in _context.Employees
                          join a in _context.AssignedEvents
                          on e.Id equals a.EmployeeId into empAssign
                          from emp in empAssign
                          join d in _context.Departments
                          on emp.DepartmentId equals d.Id
                          where e.Address == "Dumre" || e.Address == "Palpa"
                          select new DepartmentDto
                          {
                              Name = e.Fname + " " + e.Lname,
                              DepartmentName = d.Name,
                              Salary = d.Salary,
                              StartTime = emp.StartDate
                          }

                         ).ToList();
            return result;
        }

        //join hour in _context.HourLogDetails
        //on e.Id equals hour.EmployeeId into empHour
        //group empHour by e.Fname into newGroup
        //orderby newGroup.Key
        public List<EmployeeCandidateHourDto> Show()
        {
            //var result = (from e in _context.Employees
            //              join Hour in _context.HourLogDetails
            //              on e.Id equals Hour.EmployeeId into employeeHour
            //              from empHour in employeeHour
            //              join can in _context.Candidates
            //              on empHour.CandidateId equals can.Id
            //              where e.Fname=="Sita" 
            //              //orderby can.StartTime=(DateTime)2021-05-02 21:06:24.5631553
            //              select new EmployeeCandidateHourDto()
            //                 {
            //                  Firstname=e.Fname ,
            //                 // Firstname = newGroup.Key,
            //                  candidateHours = (
            //                               from c in _context.Candidates
            //                               join h in _context.HourLogDetails
            //                               on c.Id equals h.CandidateId
            //                               select new CandidateHourDto
            //                               {
            //                                   name = c.Fname + " " + c.Lname,
            //                                   Hour = h.Hour
            //                               }).ToList()
            //                  //Totalhour = newGroup.Sum(x=>x.Select(e))

            //}).ToList();

            var result = _context.Employees
                .Select(x => new EmployeeCandidateHourDto
                {
                    EmployeeId=x.Id,
                    EmployeeName=x.Fname+" "+x.Lname,
                    CandidateHours=x.HourLogDetails.Select(y=>new CandidateHourDto {
                        CandidateName=y.Candidate.Fname+" "+y.Candidate.Lname,
                        Hour=y.Hour
                    }).ToList(),
                    TotalHour=x.HourLogDetails.Sum(z=>z.Hour)
                }).ToList();

            //var result1 = (from hourlog in _context.HourLogDetails
            //               group hourlog by hourlog.EmployeeId into hlProj
            //               select new EmployeeCandidateHourDto
            //               {
            //                   EmployeeId = hlProj.Key,
            //                   EmployeeName = (from each in hlProj
            //                                   select each.Employee.Fname).First(),

            //                   CandidateHours = (from each in hlProj
            //                                     select new CandidateHourDto
            //                                     {
            //                                         CandidateName = each.Candidate.Fname + " " + each.Candidate.Lname,
            //                                         Hour = each.Hour
            //                                     }).ToList(),

            //                   TotalHour = hlProj.Sum(x => x.Hour)

            //               }).ToList();



            return result;   
                
        }

       public  List<CandidateEmployeeHour1Dto> CandidateEmployeeHourDetails()
        {
            var result = _context.Candidates.Where(x=> x.HourLogDetails.Count!=0).Select(
                x=> new CandidateEmployeeHour1Dto
                {
                    CandidateId=x.Id,
                    CandidateName=x.Fname+" "+x.Lname,
                    Employee=x.HourLogDetails.Select(y=> new EmployeeHour1Dto { 
                        EmployeeName=y.Employee.Fname+" "+y.Employee.Lname,
                        Hour=y.Hour
                    }).ToList(),
                    TotalHour=x.HourLogDetails.Sum(z=>z.Hour)
                }
                ).ToList();
            return result;
        }


    }
}