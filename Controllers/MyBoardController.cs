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
