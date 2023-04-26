using Books.DataAccess.Data;
using Books.DataAccess.Models;
using Books.DataAccess.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.Configure<AppDbContext>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IRepository<Publisher>, PublisherRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
