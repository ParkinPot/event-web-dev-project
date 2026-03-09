using System.ComponentModel.DataAnnotations;

namespace event_web_dev_project.Models;

public class Join
{
    [Required]
    public int PostId { get; set; }

    [Required]
    public string ApplicantName { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    
}

public class JoinViewModel
{
    public int PostId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public int SpotsLeft { get; set; }
    public string Status { get; set; } = string.Empty;
    public int ApplicationsCount { get; set; }
    public string ApplicationMode { get; set; } = string.Empty;

    public string UserStatus { get; set; } = "apply"; // "none", "pending", "accepted", "rejected", "owner"
}