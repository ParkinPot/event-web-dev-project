using Microsoft.EntityFrameworkCore;
using event_web_dev_project.Data;

namespace event_web_dev_project.Services;

public class ExpiryCheckerService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<ExpiryCheckerService> _logger;

    public ExpiryCheckerService(IServiceScopeFactory scopeFactory, ILogger<ExpiryCheckerService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await CheckExpiredPosts();
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }
    }

    private async Task CheckExpiredPosts()
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var now = DateTime.Now;
            _logger.LogInformation("ExpiryChecker: now={Now}, checking...", now);

            var expired = await db.ActivityPosts
                .Where(p => p.Status == "Open" && !p.IsDeleted && p.ExpiresAt < now)
                .ToListAsync();

            _logger.LogInformation("ExpiryChecker: found {Count} expired posts", expired.Count);

            if (!expired.Any()) return;

            foreach (var post in expired)
            {
                post.Status = "Expired";
                _logger.LogInformation("Marked expired: {Id} '{Title}'", post.Id, post.Title);
            }

            await db.SaveChangesAsync();
        }
}