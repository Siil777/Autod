using Autod.AplicationServices.Services;
using Autod.Core.Domain;
using Autod.Core.ServiceInterface;
using Autod.Data;
using Microsoft.EntityFrameworkCore;

 //Complete

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AutoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//AddScoped method, a new instance of LandingPageServices will be
//created for each scope (HTTP request in the web application)
builder.Services.AddScoped<ILandingPageServices, LandingPageServices>();
builder.Services.AddScoped<ICarService, CarServiceServices>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();

    app.UseSession();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

