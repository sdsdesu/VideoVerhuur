using Microsoft.EntityFrameworkCore;
using VideoVerhuurData.Models;
using VideoVerhuurData.Repositories;
using VideoVerhuurWeb.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<VideoVerhuurDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VideoVerhuurConnection"), x => x.MigrationsAssembly("VideoVerhuurData")));
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<LoginService>();
builder.Services.AddTransient<ILoginRepository, SQLLoginRepository>();
builder.Services.AddTransient<FilmService>();
builder.Services.AddTransient<IFilmRepository, SQLFilmRepository>();

builder.Services.AddSession();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();


app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.UseSession();
app.Run();
