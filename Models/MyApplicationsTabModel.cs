namespace event_web_dev_project.Models
{
    public class MyApplicationsTabModel
    {
        public const string StatusPending = "Pending";
        public const string StatusAccepted = "Accepted";
        public const string StatusRejected = "Rejected";

        public List<ApplicationCardModel> Applications { get; set; } = new();

        public int TotalApplications => Applications.Count;
        public int PendingApplications => Applications.Count(a => a.Status == StatusPending);
        public int AcceptedApplications => Applications.Count(a => a.Status == StatusAccepted);
        public int RejectedApplications => Applications.Count(a => a.Status == StatusRejected);
    }
}
