using RazorPages.Models;

namespace RazorPages.Services;

public interface IEmployeeRepository
{
    public IEnumerable<Employee> GetEmployees();
}