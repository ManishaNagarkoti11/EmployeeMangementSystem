using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangementSystem.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<AssignedEvent> AssignedEvents { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HourLogDetail> HourLogDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CandidateStatus> CandidateStatus { get; set; }
    }
}
