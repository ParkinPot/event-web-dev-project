using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using event_web_dev_project.Data;
using event_web_dev_project.Models;

namespace event_web_dev_project.Controllers;

public class ActivityPostController : Controller
{
    private readonly AppDbContext _db;

    public ActivityPostController(AppDbContext db)
    {
        _db = db;
    }

    // GET /ActivityPost/Index
    // Shows a specific post (by ?id=) or defaults to the first open post.
    public async Task<IActionResult> Index(int? id)
    {
        // Only load posts that are NOT soft-deleted
        var allPosts = await _db.ActivityPosts
            .Where(p => !p.IsDeleted)
            .OrderByDescending(p => p.PostedAt)
            .ToListAsync();

        if (!allPosts.Any())
            return View(null);

        var selectedPost = id.HasValue
            ? allPosts.FirstOrDefault(p => p.Id == id.Value)
            : allPosts.First();

        if (selectedPost == null)
            return NotFound();

        selectedPost.Applications = await _db.PostApplications
            .Where(a => a.PostId == selectedPost.Id)
            .OrderBy(a => a.AppliedAt)
            .ToListAsync();

        ViewBag.AllPosts = allPosts;

        return View(selectedPost);
    }

    // GET /ActivityPost/Archive
    // Shows all soft-deleted (closed) posts
    public async Task<IActionResult> Archive()
    {
        var archivedPosts = await _db.ActivityPosts
            .Where(p => p.IsDeleted)
            .OrderByDescending(p => p.DeletedAt)
            .ToListAsync();

        return View(archivedPosts);
    }

    // POST /ActivityPost/ClosePost
    // Sets status to Closed AND soft-deletes the post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ClosePost(int id)
    {
        var post = await _db.ActivityPosts.FindAsync(id);
        if (post == null) return NotFound();

        post.Status = "Closed";
        post.IsDeleted = true;
        post.DeletedAt = DateTime.Now;

        await _db.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    // POST /ActivityPost/RestorePost
    // Recovers a soft-deleted post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RestorePost(int id)
    {
        var post = await _db.ActivityPosts.FindAsync(id);
        if (post == null) return NotFound();

        post.Status = "Open";
        post.IsDeleted = false;
        post.DeletedAt = null;

        await _db.SaveChangesAsync();

        return RedirectToAction("Archive");
    }

    // POST /ActivityPost/HardDeletePost
    // PERMANENTLY deletes a post and all its applications
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> HardDeletePost(int id)
    {
        var post = await _db.ActivityPosts
            .Include(p => p.Applications)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (post == null) return NotFound();

        _db.PostApplications.RemoveRange(post.Applications);
        _db.ActivityPosts.Remove(post);
        await _db.SaveChangesAsync();

        return RedirectToAction("Archive");
    }

    // POST /ActivityPost/AcceptApplication
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AcceptApplication(int applicationId, int postId)
    {
        var application = await _db.PostApplications.FindAsync(applicationId);
        if (application == null) return NotFound();

        application.Status = "Accepted";

        var post = await _db.ActivityPosts.FindAsync(postId);
        if (post != null && post.CurrentMembers < post.MaxMembers)
            post.CurrentMembers++;

        await _db.SaveChangesAsync();

        return RedirectToAction("Index", new { id = postId });
    }

    // POST /ActivityPost/RejectApplication
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RejectApplication(int applicationId, int postId)
    {
        var application = await _db.PostApplications.FindAsync(applicationId);
        if (application == null) return NotFound();

        application.Status = "Rejected";
        await _db.SaveChangesAsync();

        return RedirectToAction("Index", new { id = postId });
    }

    // POST /ActivityPost/Apply
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Apply(int postId, string applicantName, string message)
    {
        var post = await _db.ActivityPosts.FindAsync(postId);
        if (post == null || post.Status == "Closed" || post.IsDeleted)
            return NotFound();

        var application = new PostApplication
        {
            PostId = postId,
            ApplicantName = applicantName,
            Message = message,
            Status = "Pending",
            AppliedAt = DateTime.Now
        };

        _db.PostApplications.Add(application);
        await _db.SaveChangesAsync();

        return RedirectToAction("Index", new { id = postId });
    }

    
}
