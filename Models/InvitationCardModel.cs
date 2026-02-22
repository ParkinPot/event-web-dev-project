namespace event_web_dev_project.Models
{
    public class InvitationCardModel
    {
        public string? Title { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string? Message { get; set; }

        public string StatusMessage =>
            Status switch
            {
                "Accepted" => "🎉 Congratulations! Your application has been accepted. The organizer will contact you with more details.",
                "Pending"  => "⏳ Your application is currently under review. Please wait for the organizer's response.",
                "Rejected" => "❌ Unfortunately, your application was not approved. You may explore other events.",
                _ => ""
            };
    }
}