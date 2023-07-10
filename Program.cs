using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using System.Data;
using IndeedJobs;
using Microsoft.EntityFrameworkCore;
using IndeedJobs.Interfaces;
using IndeedJobs.Data;
using System.IO;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>((s) =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
    IDbConnection conn = new MySqlConnection(connectionString);
    conn.Open();
    return conn;
});


builder.Services.AddScoped<IJobRepository, JobRepository>();

// Register the HttpClient and IndeedJobAPIClient in the service container
builder.Services.AddHttpClient();
builder.Services.AddTransient<IndeedJobAPIClient>();

// Build the configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

//Add DbContext
builder.Services.AddDbContext<IndeedJobsContext>((options, context) =>
{
    context.UseMySql(
        configuration.GetConnectionString("MySqlConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)) 
    );
});


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
