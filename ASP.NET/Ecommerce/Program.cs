var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllersWithViews();

// Register session services with configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Set session timeout duration as needed
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); // Add this before UseRouting()
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();

