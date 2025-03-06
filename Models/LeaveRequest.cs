using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveId { get; set; }

        [Required, ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required]
        public string LeaveType { get; set; }  // Sick, Casual, Annual

        [Required, DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public string Status { get; set; } = "Pending"; // Default: Pending

        public string Reason { get; set; }

        public DateTime AppliedOn { get; set; } = DateTime.Now;

    }
}
