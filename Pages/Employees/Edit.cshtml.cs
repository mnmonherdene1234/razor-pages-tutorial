using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using RazorPages.Models;

namespace RazorPages.Pages.Employees;

public class EditModel : PageModel
{
    private readonly IEmployeeRepository employeeRepository;
    [BindProperty]
    public Employee? Employee { get; set; }

    public EditModel(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }
    public IActionResult OnGet(int id)
    {
        Employee = employeeRepository.GetEmployee(id);

        if (Employee != null)
        {
            return Page();
        }
        else
        {
            return RedirectToPage("/NotFound");
        }
    }

    public IActionResult OnPost(Employee employee)
    {
        Employee = employeeRepository.Update(employee);
        return RedirectToPage("/Employees/Index");
    }
}