using System.ComponentModel.DataAnnotations;

namespace WAAI.Features.Wizard.Steps.Personal;

public record PersonalInfo
{
    [Required(ErrorMessage = "Full name is required")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = "";

    [Phone(ErrorMessage = "Invalid phone format")]
    public string Phone { get; set; } = "";
}
