using RazorPages.Models;

namespace RazorPages.Services;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetEmployees();
}