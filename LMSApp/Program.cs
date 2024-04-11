﻿using LMSApp.Api.Models;
using LMSApp.Api.Repositories;
using LMSApp.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();



string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LmsContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IuserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

