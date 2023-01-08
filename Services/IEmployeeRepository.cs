using RazorPages.Models;

namespace RazorPages.Services;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetEmployees();
    Employee? GetEmployee(int id);
    Employee? Update(Employee updatedEmployee);
    Employee? Delete(int id);
}