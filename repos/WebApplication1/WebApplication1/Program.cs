var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

// Configure session options
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1); // Set session timeout
});
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();
app.MapDefaultControllerRoute();
app.Run();
