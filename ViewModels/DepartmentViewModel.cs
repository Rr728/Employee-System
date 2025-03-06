using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        public string Name { get; set; }
    }
}

