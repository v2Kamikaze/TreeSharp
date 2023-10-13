using Microsoft.EntityFrameworkCore;

namespace treeSharp.Database;

public class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=tree.db;Cache=Shared");
}