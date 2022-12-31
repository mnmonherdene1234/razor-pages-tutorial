using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace RazorPages.Pages.Employees;

public class IndexModel : PageModel
{
    private readonly IEmployeeRepository employeeRepository;
    public string Message { get; set; }
    public IEnumerable<Employee>? Employees { get; set; }

    public IndexModel(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
        Message = "Employees";
    }

    public void OnGet()
    {
        Employees = employeeRepository.GetEmployees();
    }
}