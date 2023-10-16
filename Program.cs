using TreeSharp.Database;
using TreeSharp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddSingleton(x => new TreeBuilderService());

var app = builder.Build();
app.MapControllers();
app.Run();
