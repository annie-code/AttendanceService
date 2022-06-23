using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAttendanceService.Models
{
    public class AttendanceModel
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public double AttendancePercentage { get; set; }
    }
}
