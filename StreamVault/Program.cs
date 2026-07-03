using Microsoft.EntityFrameworkCore;
using StreamVaultAdmin.Data;
using StreamVaultAdmin.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC
builder.Services.AddControllersWithViews();

// Configure EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IContentService, ContentService>();

var app = builder.Build();

// Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Create database and seed sample data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();

    SeedData.Initialize(context);
}

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Content}/{action=Index}/{id?}");

app.Run();