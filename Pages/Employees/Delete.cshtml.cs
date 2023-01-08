using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using RazorPages.Services;
using RazorPages.Models;

namespace RazorPages.Pages.Employees;

public class DeleteModel : PageModel
{
    private readonly IEmployeeRepository employeeRepository;
    [BindProperty]
    public Employee? Employee { get; set; }

    public DeleteModel(IEmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
    }

    public IActionResult OnGet(int id)
    {
        Employee = employeeRepository.GetEmployee(id);
        
        if (Employee == null)
        {
            return RedirectToPage("/NotFound");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        Employee? deletedEmployee = employeeRepository.Delete(Employee.Id);

        if (deletedEmployee == null)
        {
            return RedirectToPage("/NotFound");
        }

        return RedirectToPage("Index");
    }
}