using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAsync();
        Task AddAsync(Attendance attendance);
    }
}