using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // Added for UserManager
using event_web_dev_project.Models;
using event_web_dev_project.Data;

namespace event_web_dev_project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, AppDbContext context, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        // Load only open, non-deleted posts
        // Include applications so we can show applicant counts
        var posts = await _context.ActivityPosts
            .Where(p => p.Status != "Deleted" && p.Status == "Open")
            .Include(p => p.Applications)
            .OrderByDescending(p => p.PostedAt)
            .ToListAsync();

        return View(posts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            // For demo/dev purposes, if not logged in, show the first seeded user
            user = await _context.Users.FirstOrDefaultAsync();
            if (user == null) return RedirectToAction("Index");
        }

        var viewModel = new ProfileViewModel
        {
            UserId = user.Id,
            DisplayName = user.DisplayName ?? user.UserName ?? "Unknown User",
            Email = user.Email ?? "",
            About = user.About,
            AvatarUrl = user.AvatarUrl,
            Tags = user.Tags,
            Interests = user.Interests
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateProfile(ProfileViewModel model)
    {
        if (!ModelState.IsValid) return View("Profile", model);

        var user = await _userManager.FindByIdAsync(model.UserId);
        if (user == null) return NotFound();

        user.DisplayName = model.DisplayName;
        user.About = model.About;
        user.Tags = model.Tags;
        user.Interests = model.Interests;
        user.AvatarUrl = model.AvatarUrl;

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return RedirectToAction(nameof(Profile));
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View("Profile", model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
