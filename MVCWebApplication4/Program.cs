

using CloudinaryDotNet;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using mvcRegistrations.Data;
using MVCWebApplication4.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<MainDbContext>(options =>
options.UseSqlServer("Data Source=LAPTOP-KP5V0F14\\SQLSERVER1;Initial Catalog=ILSDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));


builder.Services.AddDbContext<AuthDbContext>(options =>
  options.UseSqlServer("Data Source=LAPTOP-KP5V0F14;Initial Catalog=AuthDbContext;Integrated Security=True;Trust Server Certificate=True"));

builder.Services.AddDbContext<ModernFoodDbContext>(options =>
options.UseSqlServer("Data Source=LAPTOP-KP5V0F14;Initial Catalog=ModernDb;Integrated Security=True;Trust Server Certificate=True"));




builder.Services.AddIdentity<IdentityUser , IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

Account account = new Account(

  "dgk8isogn",
 "857951811896644",
  "6ZswYXerNmbHl8Du6yLQz9DB3VY"
);
Cloudinary cloudinary = new Cloudinary(account);

builder.Services.AddSingleton<Cloudinary>(cloudinary);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
