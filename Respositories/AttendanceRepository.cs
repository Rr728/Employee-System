using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;
        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Attendance>> GetAllAsync()
        {
            return await _context.Attendances.ToListAsync();
        }
        public async Task AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
        }
    }
}
