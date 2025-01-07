using Microsoft.EntityFrameworkCore;
using TaskManager.API.Entities;

namespace TaskManager.API.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<TaskItem> Tasks { get; set; }
}
