using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        public async Task<IActionResult> Index()
        {
            var attendanceRecords = await _attendanceRepository.GetAllAsync();
            return View(attendanceRecords);
        }
        [HttpPost]
        public async Task<IActionResult> MarkAttendance(int employeeId, bool isPresent)
        {
            var attendance = new Attendance
            {
                EmployeeId = employeeId,
                Date = DateTime.UtcNow,
                IsPresent = isPresent
            };
            await _attendanceRepository.AddAsync(attendance);
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }

    }
}
