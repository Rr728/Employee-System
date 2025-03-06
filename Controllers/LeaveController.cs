using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication2.Repositories;
using WebApplication2.ViewModels;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace WebApplication2.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ILeaveRepository _leaveRepository;

        public LeaveController(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        // Show Leave Request Form
        public IActionResult Apply()
        {
            return View();
        }

        // Handle Leave Application
        [HttpPost]
        public async Task<IActionResult> Create(LeaveRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var leaveRequest = new LeaveRequest
            {
                EmployeeId = model.EmployeeId,
                LeaveType = model.LeaveType,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Reason = model.Reason,
                Status = "Pending"
            };

            await _leaveRepository.AddAsync(leaveRequest); 

            return RedirectToAction("MyLeaves");
        }

        // Show Employee's Leave Requests
        public async Task<IActionResult> MyLeaves()
        {
            var employeeId = 1; // Replace with logged-in employee ID
            var leaves = await _leaveRepository.GetByEmployeeIdAsync(employeeId);
            return View(leaves);
        }

        // Approve/Reject Leave Request (Manager/Admin)
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int leaveId, string status)
        {
            var leave = await _leaveRepository.GetByIdAsync(leaveId);
            if (leave != null)
            {
                leave.Status = status;
                await _leaveRepository.UpdateAsync(leave);
            }
            return RedirectToAction("AllLeaves");
        }

        // POST: Leave/Apply
        [HttpPost]
        public async Task<IActionResult> Apply(LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                // Save the leave request
                await _leaveRepository.AddAsync(leaveRequest);
                return RedirectToAction("Status");
            }
            return View(leaveRequest);
        }

        // GET: Leave/Status
        public async Task<IActionResult> Status()
        {
            var employeeId = 1; // Replace with the actual logged-in employee ID
            var leaves = await _leaveRepository.GetByEmployeeIdAsync(employeeId);

            if (leaves == null || !leaves.Any())
            {
                Console.WriteLine("No leave records found for employee ID: " + employeeId);
            }
            else
            {
                foreach (var leave in leaves)
                {
                    Console.WriteLine($"Leave ID: {leave.LeaveId}, Type: {leave.LeaveType}, Status: {leave.Status}");
                }
            }

            return View(leaves.ToList());  // Convert IQueryable to List and pass to View
        }



        /* Show All Leave Requests (Admin/Manager)
        public async Task<IActionResult> AllLeaves()
        {
            var leaves = await _leaveRepository.GetAllAsync();  // This will now return a List<LeaveRequest>
            return View(leaves);
        }
        */
    }
}
