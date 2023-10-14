using Microsoft.EntityFrameworkCore;

namespace TreeSharp.Database;

public class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=tree.db;Cache=Shared");
}