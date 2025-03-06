using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
