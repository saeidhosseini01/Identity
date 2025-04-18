using Authorization.Infrastructure;
using Authorization.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;







var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IUserValidator<AppUser>, CustomUserValidator>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Server=.;Initial Catalog=IdentityDB;Integrated Security=True;TrustServerCertificate=True;"));
builder.Services.AddIdentity<AppUser, IdentityRole>(c =>
{
    c.Password.RequiredLength = 3;
    c.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddMvc();


var app = builder.Build();





app.UseStaticFiles();
app.UseStatusCodePages();
app.UseAuthentication();
app.UseDeveloperExceptionPage();
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
