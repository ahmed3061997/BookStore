using BookStore.Core.Domain;
using BookStore.Core.Features.Auhors.Service;
using BookStore.Core.Features.Books.Service;
using BookStore.Core.Generic.Middleware;
using BookStore.Core.Repositiory;
using BookStore.Core.Repository;
using BookStore.Core.Services;
using BookStore.Core.Services.Authentication;
using BookStore.Core.Services.MigrationManager;
using MediatR;
using Microsoft.AspNetCore.Identity;
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

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 7;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;
    opt.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<BookStoreDbContext>();

builder.Services.AddScoped<IQueryRepository<Author>, AuthorRepo>();
builder.Services.AddScoped<IQueryRepository<Book>, BookRepo>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsFactory>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors_policy", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

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
app.UseCors("cors_policy");
app.UseAuthentication();
app.ConfigureExceptionHandler();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.MigrateDatabase();

app.Run();
