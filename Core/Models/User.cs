namespace WAAI.Core.Models;

public class User
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public bool Newsletter { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
