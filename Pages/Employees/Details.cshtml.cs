using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RazorPages.Services;
using RazorPages.Models;

namespace RazorPages.Pages.Employees;

public class DetailsModel : PageModel
{
    public Employee Employee { get; set; }
    [TempData]
    public string? Message { get; set; }
    public IEmployeeRepository employeeRepository { get; set; }
    public DetailsModel(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
        Employee = new Employee();
    }

    public IActionResult OnGet(int id = 1)
    {
        Employee = employeeRepository.GetEmployee(id);

        if (Employee == null)
        {
            return RedirectToPage("/NotFound");
        }

        return Page();
    }
}