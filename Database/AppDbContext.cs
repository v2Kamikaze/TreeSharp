using Microsoft.EntityFrameworkCore;
using TreeSharp.Models;

namespace TreeSharp.Database;

public class AppDbContext : DbContext
{
    public DbSet<Record> Records { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=tree.db;Cache=Shared");
}