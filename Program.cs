using System;
using WebApplication2.Data;
using WebApplication2.Respositories;

using Microsoft.EntityFrameworkCore;
using EFCoreWithAsp.netCore.Repositories;
using WebApplication2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register DbContext

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repository to DI container
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Register your repository
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

// Register Attendance Repository
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();

builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();

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
