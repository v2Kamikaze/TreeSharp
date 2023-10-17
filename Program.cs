using TreeSharp.Database;
using TreeSharp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<TreeBuilderService>();

var app = builder.Build();
app.MapControllers();
app.Run();

/* 
using TreeSharp.Services;

var builder = new TreeBuilderService();
var node = builder.BuildTree();
builder.PrintNodeRecursive(node); */