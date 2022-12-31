using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using RazorPages.Models;

namespace RazorPages.Pages.Employees;

public class DetailsModel : PageModel
{
    public Employee? Employee { get; set; }
    public IEmployeeRepository employeeRepository { get; set; }
    public DetailsModel(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public void OnGet(int id = 1)
    {
        Employee = employeeRepository.GetEmployee(id);
    }
}