using System.Diagnostics;
using DomainCentricDemo.Application;
using DomainCentricDemo.Application.Implentation;
using DomainCentricDemo.Infrastructure;
using DomainCentricDemo.Infrastructure.Queries;
using DomainCentricDemo.Infrastructure.Repositories;
using DomainCentricDemo.Web.Data;
using DomainCentricDemo.Web.Data.DataInitializer;
using DomainCentricDemo.Web.UserManagement;
using DomainCentricDemo.Web.UserManagement.Handler;
using DomainCentricDemo.Web.UserManagement.Requirement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add-Migration InitUser -Project DomainCentricDemo.Web -Context ApplicationDbContext
// Update-Database -Context ApplicationDbContext
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Lockout.AllowedForNewUsers = true;
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();

builder.Services.AddRazorPages();

builder.Services.AddScoped<IBookQuery, BookQuery>();
builder.Services.AddScoped<IBookCommand, BookCommand>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddDbContext<BookContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BookConnectionString"), opt =>
        {
            opt.MigrationsAssembly
                ("DomainCentricDemo.Infrastructure");
        }));
// Add-Migration Init -Project DomainCentricDemo.InfraStructure -Context BookContext
// Update-Database -Context BookContext

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        "IsAdminPolicy",
        policyBuilder => policyBuilder
            .RequireClaim(ClaimsTypes.Admin));
    options.AddPolicy(
        "IsSoleAuthorOrAdminPolicy",
        policyBuilder => policyBuilder.AddRequirements(
            new IsSoleAuthorOrAdminRequirement()
        ));
});

builder.Services.AddScoped<IAuthorizationHandler, IsSoleAuthorOrAdminHandler>();

var app = builder.Build();

SeedUsers();
SeedBooks();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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


void SeedUsers()
{
    using var scope = app.Services.CreateScope();
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        UserAndRoleDataInitializer.SeedDataAsync(userManager, roleManager).Wait();
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
}

void SeedBooks()
{
    using var scope = app.Services.CreateScope();
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var db = serviceProvider.GetRequiredService<BookContext>();
        db.Database.EnsureCreated();
        AuthorAndBookDataInitializer.SeedData(db);
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex.Message);
    }
}