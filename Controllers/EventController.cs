using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using event_web_dev_project.Data;

namespace event_web_dev_project.Controllers;

public class EventController : Controller
{
    // GET /Event/Join?state=apply|pending|accepted|rejected|owner
   private readonly AppDbContext _db;

    public EventController(AppDbContext db)
    {
        _db = db;
    }

    // GET /Join/Index
    public async Task<IActionResult> Join(int id)
{
    var post = await _db.ActivityPosts
        .Include(p => p.Applications)
        .FirstOrDefaultAsync(p => p.Id == id);

    if (post == null)
        return NotFound();

    return View(post);
}
}
