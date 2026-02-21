namespace event_web_dev_project.Models
{
    public class MyPostsTabModel
    {
        public const string StatusOpen = "Open";
        public const string StatusClosed = "Closed";
        public const string StatusExpired = "Expired";

        public List<PostCardModel> Posts { get; set; } = new();

        public int TotalPosts => Posts.Count;
        public int OpenPosts => Posts.Count(p => p.Status == StatusOpen);
        public int ClosedPosts => Posts.Count(p => p.Status == StatusClosed);
        public int ExpiredPosts => Posts.Count(p => p.Status == StatusExpired);
        public int TotalApplications => Posts.Sum(p => p.NumApplication);
    }
}
