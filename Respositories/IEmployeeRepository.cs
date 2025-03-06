using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Respositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeViewModel> GetByIdAsync(int id);
        IQueryable<EmployeeViewModel> GetAllAsync();
        Task AddAsync(EmployeeViewModel employee);
        Task UpdateAsync(EmployeeViewModel employee);
        Task DeleteAsync(int Id);

        Task<List<Department>> GetAllDepartments();
    }
}
