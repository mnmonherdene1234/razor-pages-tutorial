using RazorPages.Models;

namespace RazorPages.Services;

public class MockEmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees;

    public MockEmployeeRepository()
    {
        _employees = new List<Employee>{
            new Employee{
                Id = 1,
                Name = "Monherdene",
                Email = "mnmonherdene0529@gmail.com",
                Photo = "img1.jpeg",
                Department = Dept.HR
            },
            new Employee{
                Id = 2,
                Name = "Alex",
                Email = "alex1234@gmail.com",
                Photo = "img2.jpg",
                Department = Dept.IT
            },
            new Employee{
                Id = 3,
                Name = "Naba",
                Email = "naba88@gmail.com",
                Photo = "img3.jpeg",
                Department = Dept.Payroll
            }
        };
    }

    public Employee? GetEmployee(int id)
    {
        return _employees.FirstOrDefault((employee) => employee.Id == id);
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _employees;
    }

    public Employee? Update(Employee updatedEmployee)
    {
        Employee? employee = _employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);

        if (employee != null)
        {
            employee.Name = updatedEmployee.Name;
            employee.Email = updatedEmployee.Email;
            employee.Department = updatedEmployee.Department;
            employee.Photo = updatedEmployee.Photo;
            return employee;
        }
        else
        {
            return null;
        }
    }
}