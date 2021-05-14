using EmployeeMangementSystem.Models;
using EmployeeMangementSystem.Models.DTO;
using EmployeeMangementSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRespository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void addEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<EmployeeDto> showEmployees()
        {
            List<EmployeeDto> result = (from employee in _context.Employees
                                        select new EmployeeDto
                                        {
                                            Firstname = employee.Fname,
                                            Lastname = employee.Lname
                                        }).ToList();
            return result;
        }
        public List<Employee> ShowAccordingAddress(string address)
        {
            var manisha = _context.Employees.Where(x => x.Address == address).ToList();
             return manisha;
        }

        public void addAssignedEvent(AssignedEvent events)
        {
            DateTime now = DateTime.Now;
            events.AddDate = now;
            _context.AssignedEvents.Add(events);
            var candidateIds = _context.HourLogDetails.Where(x => x.EmployeeId == events.EmployeeId).Select(x => x.CandidateId).ToList();
            List<Candidate> candidates = _context.Candidates.Where(x => candidateIds.Contains(x.Id) &&  x.StatusId!=(int)CandidateStatusEnum.Available).ToList();
            var updateCandidate =candidates.Select(x =>
            {
                if(x.IsActive)
                {
                    x.IsActive = false;
                }
                x.StatusId = (int)CandidateStatusEnum.Available;
                return x;
            }).ToList();
            _context.Candidates.UpdateRange(updateCandidate);

            _context.SaveChanges();
        }
        public List<AssignedEvent> ShowAssignedEvent()
        {
            List<AssignedEvent> result = _context.AssignedEvents.ToList();
            return result;
        }
        public void addHourLogDetail(HourLogDetail details)
        {
            var check = _context.Employees.Where(x => x.Id == details.EmployeeId && x.IsActive == false).FirstOrDefault();
            if (check != null)
            {
                check.IsActive = true;
                _context.Employees.Update(check);
                _context.SaveChanges();
            }
            _context.HourLogDetails.Add(details);
            _context.SaveChanges();
            
        }
        public List<HourLogDetail> ShowHourLogDetail()
        {
            List<HourLogDetail> result = _context.HourLogDetails.ToList();
            return result;
        }
        public List<EmployeeDto> ShowTask2()
        {
            var result = (from e in _context.Employees
                          join a in _context.AssignedEvents
                          on e.Id equals a.EmployeeId into empAssign
                          from emp in empAssign
                          join d in _context.Departments
                          on emp.DepartmentId equals d.Id
                          where d.Name == "IT"
                          select new EmployeeDto
                          {
                              Firstname = e.Fname,
                              Lastname = e.Lname

                          }
                      ).ToList();


            return result;
        }
        // _context.Employees.Where(x=>x.IsActive==false).Select x 

        public List<Employee> AvailableEmployees()
        {
            List<Employee> result = (_context.Employees.Where(x=>x.IsActive==false)).ToList();
            return result;
           

            }
        public void UpdateStatus()
        {
            DateTime weekAgoDate = DateTime.Now.AddDays(-7);
            var data = _context.Employees
                        .Select(x => new EmployeeHourDto
                        {
                            Employee = x,
                            HourLog = x.HourLogDetails.OrderByDescending(y => y.Date).FirstOrDefault()
                        }).ToList();//every  Employee's latest HourLog Entries
            var update = data.Where(x => x.HourLog == null|| x.HourLog.Date < weekAgoDate)
                        .Select(x=>
                            { 
                                x.Employee.IsActive = false;
                                return x.Employee;
                            }).ToList();
            //Update Employee's status IsActive=false  when   Employees latest Date  if  less than week ago
            _context.Employees.UpdateRange(update);
            _context.SaveChanges();

        }

       
    }
    }
