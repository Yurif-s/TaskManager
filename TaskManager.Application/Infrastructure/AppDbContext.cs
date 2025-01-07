using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Entities;

namespace TaskManager.Application.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<TaskItem> Tasks { get; set; }
}
