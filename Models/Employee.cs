using System.ComponentModel.DataAnnotations;
namespace RazorPages.Models;

public class Employee
{
    public int Id { get; set; }
    [Required]
    [MinLength(2)]
    public string? Name { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    public string? Photo { get; set; }
    public Dept? Department { get; set; }
}