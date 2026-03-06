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