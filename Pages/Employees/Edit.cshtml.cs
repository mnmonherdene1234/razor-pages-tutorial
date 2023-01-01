using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Services;
using RazorPages.Models;

namespace RazorPages.Pages.Employees;

public class EditModel : PageModel
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IWebHostEnvironment webHostEnvironment;
    [BindProperty]
    public Employee? Employee { get; set; }
    [BindProperty]
    public IFormFile? Photo { get; set; }

    public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
    {
        this.employeeRepository = employeeRepository;
        this.webHostEnvironment = webHostEnvironment;
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

    public IActionResult OnPost()
    {
        if (Photo != null && Employee != null)
        {
            if (Employee.Photo != null)
            {
                string filepath = Path.Combine(webHostEnvironment.WebRootPath, "images", Employee.Photo);
                System.IO.File.Delete(filepath);
            }

            Employee.Photo = ProcessUploadFile();
        }

        if (Employee != null)
        {
            Employee = employeeRepository.Update(Employee);
        }

        return RedirectToPage("Index");
    }

    public string? ProcessUploadFile()
    {
        string? uniqueFileName = null;

        if (Photo != null)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
        }

        return uniqueFileName;
    }
}