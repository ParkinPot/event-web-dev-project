using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using event_web_dev_project.Models;

namespace event_web_dev_project.Controllers;

public class MyBoardController : Controller
{
    public IActionResult Index()
    {
        var model = new MyBoardViewModel
        {
            PostsTab = new MyPostsTabModel
            {
                Posts = new List<PostCardModel>
                {
                    new PostCardModel
                    {
                        Category = "Sports",
                        Status = MyPostsTabModel.StatusOpen,
                        Title = "Looking for Football Teammates",
                        Description = "Join our Sunday afternoon football match at Central Park. All skill levels welcome — just bring your boots and good energy!",
                        Location = "Central Park, NY",
                        CurrentMember = 8,
                        MaxMember = 11,
                        PublishDate = new DateTime(2026, 2, 10),
                        ExpirationDate = new DateTime(2026, 3, 10),
                        Author = "John Doe",
                        NumApplication = 5
                    }
                }
            },
            ApplicationsTab = new MyApplicationsTabModel
            {
                Applications = new List<ApplicationCardModel>
                {
                    new ApplicationCardModel
                    {
                        Title = "Looking for Football Teammates",
                        Status = "Pending",
                        Description = "Sunday football match at Central Park.",
                        ApplicationDate = DateTime.Now.AddDays(-2),
                        Message = "Hi! I’ve been playing for 3 years and would love to join."
                    },
                    new ApplicationCardModel
                    {
                        Title = "Weekend Brunch Crew",
                        Status = "Accepted",
                        Description = "Exploring brunch spots every weekend.",
                        ApplicationDate = DateTime.Now.AddDays(-7),
                        Message = "Sounds fun! I enjoy discovering new cafes."
                    },
                    new ApplicationCardModel
                    {
                        Title = "Network Study Group",
                        Status = "Rejected",
                        Description = "Preparing for IPv4 and TCP/IP lab exam.",
                        ApplicationDate = DateTime.Now.AddDays(-1),
                        Message = "I want to improve my networking skills."
                    }
                }
            }
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
