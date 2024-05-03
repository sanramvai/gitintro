using Bethanypieshop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<ICatigoryRepository, CatigoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddRazorPages();
//builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddDbContext<BethanypieshopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BethanypieshopDbContextConnection"]);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseStaticFiles();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSession();
app.MapDefaultControllerRoute();
app.MapRazorPages();

DbInitializer.Seed(app);
app.Run();
