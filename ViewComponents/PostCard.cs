using Microsoft.AspNetCore.Mvc;
using event_web_dev_project.Models;
public class PostCardViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(
        string category, 
        string status, 
        string title, 
        string description, 
        string location, 
        int currentMember, 
        int maxMember,
        DateTime publishDate,
        DateTime expirationDate,
        string author,
        int numApplication
    )
    {
        var model = new PostCardModel
        {
            Category = category,
            Status = status,
            Title = title,
            Description = description,
            Location = location,
            CurrentMember = currentMember,
            MaxMember = maxMember,
            PublishDate = publishDate,
            ExpirationDate = expirationDate,
            Author = author,
            NumApplication = numApplication
        };

        return View("_MyPostTab", model);
    }
}