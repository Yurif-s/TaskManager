﻿using Microsoft.EntityFrameworkCore;

namespace TaskManager.API.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    public DbSet<Task> Tasks { get; set; }
}
