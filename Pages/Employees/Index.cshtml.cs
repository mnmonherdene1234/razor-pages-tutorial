using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Employees;

public class IndexModel : PageModel
{
    public string Message { get; set; }
    public IndexModel()
    {
        Message = "Hello World";
    }
    public void OnGet()
    {

    }
}