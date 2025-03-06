using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;

 namespace EFCoreWithAsp.netCore.Repositories
 {
    public class LeaveRepository : ILeaveRepository
    {
        private readonly AppDbContext _dbContext;

        public LeaveRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(LeaveRequest leaveRequest)
        {
            await _dbContext.LeaveRequests.AddAsync(leaveRequest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                _dbContext.LeaveRequests.Remove(leaveRequest);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IQueryable<LeaveRequest> GetAllAsync()
        {
            return _dbContext.LeaveRequests.AsQueryable();
        }
        public async Task<IQueryable<LeaveRequest>> GetByEmployeeIdAsync(int employeeId)
        {
            return _dbContext.LeaveRequests.Where(lr => lr.EmployeeId == employeeId);
        }

        public async Task<LeaveRequest> GetByIdAsync(int id)
        {
            return await _dbContext.LeaveRequests.FindAsync(id);
        }

        public async Task UpdateAsync(LeaveRequest leaveRequest)
        {
            _dbContext.LeaveRequests.Update(leaveRequest);
            await _dbContext.SaveChangesAsync();
        }
    }
}
