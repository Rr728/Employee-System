using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface ILeaveRepository
    {
        Task<IQueryable<LeaveRequest>> GetByEmployeeIdAsync(int employeeId);
        Task<LeaveRequest> GetByIdAsync(int id);
        IQueryable<LeaveRequest> GetAllAsync();
        Task AddAsync(LeaveRequest leaveRequest);
        Task UpdateAsync(LeaveRequest leaveRequest);
        Task DeleteAsync(int id);
    }
}
