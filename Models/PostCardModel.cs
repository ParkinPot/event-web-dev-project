namespace event_web_dev_project.Models
{
    public class PostCardModel
    {
        public string? Category { get; set; }
        public string? Status { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int CurrentMember { get; set; }
        public int MaxMember { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? Author { get; set; }
        public int NumApplication { get; set; }
    }
}