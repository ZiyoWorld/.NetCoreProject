using Houzing2.Models.Domain;
using Houzing2.Repositories.Abstract;
using Houzing2.Repositories.Implimentation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatebaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

// For Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DatebaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserAuthenticationServise, UserAuthenticationService>();

// builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
