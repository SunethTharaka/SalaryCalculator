using Microsoft.EntityFrameworkCore;
using SalaryCalculator.Domain.Services;
using SalaryCalculator.Infrastructure;
using SalaryCalculator.Infrastructure.MigrationManager;
using SalaryCalculator.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<SalaryDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddScoped<ICalendarService, CalendarService>();
builder.Services.AddScoped<ISalaryService, SalaryService>();
builder.Services.AddScoped<IIncomeTaxRateRepository, IncomeTaxRateRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;
app.MigrateDatabase();
app.Run();
