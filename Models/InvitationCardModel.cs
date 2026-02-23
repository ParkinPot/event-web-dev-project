namespace event_web_dev_project.Models
{
    public class ReceivedInvitationCardModel
    {
        public string? Title { get; set; }
        public string? Status { get; set; }
        public string? Sender { get; set; }
        public DateTime ReceivedDate {get; set;}
        public DateTime EventDate {get; set;}
        public string? Message { get; set; }
    }
    public class SentInvitationCardModel
    {
        public string? Title { get; set; }
        public string? Status { get; set; }
        public string? Receiver { get; set; }
        public DateTime SentDate {get; set;}
        public DateTime EventDate {get; set;}
        public string? Message { get; set; }

        public string StatusMessage =>
            Status switch
            {
                "Accepted" => "🎉 Great news! The recipient has accepted your invitation.",
                "Pending"  => "⏳ Your invitation is awaiting the recipient’s response.",
                "Rejected" => "❌ The recipient has declined your invitation.",
                _ => ""
            };
    }
}