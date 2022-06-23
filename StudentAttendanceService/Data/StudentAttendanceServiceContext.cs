using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceService.Models;

namespace StudentAttendanceService.Data
{
    public class StudentAttendanceServiceContext : DbContext
    {
        public StudentAttendanceServiceContext (DbContextOptions<StudentAttendanceServiceContext> options)
            : base(options)
        {
        }

        public DbSet<StudentAttendanceService.Models.AttendanceModel> AttendanceModel { get; set; }
    }
}
