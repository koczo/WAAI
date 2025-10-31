using System.ComponentModel.DataAnnotations;

namespace WAAI.Features.Wizard;

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

public record AccountInfo
{
    [Required(ErrorMessage = "Username is required")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
    public string Username { get; set; } = "";

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "Confirm password is required")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = "";
}

public record PreferencesInfo
{
    [Required]
    public string Language { get; set; } = "en";

    [Required]
    public string Theme { get; set; } = "light";

    public bool Newsletter { get; set; }
}
