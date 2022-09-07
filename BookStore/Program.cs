using BookStore.Core.Domain;
using BookStore.Core.Implementations.Repositiory;
using BookStore.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options
    .UseLazyLoadingProxies()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
    .UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<IRepository<Author>, AuthorRepo>();
builder.Services.AddScoped<IRepository<Book>, BookRepo>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
