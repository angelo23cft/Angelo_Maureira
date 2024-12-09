using Microsoft.EntityFrameworkCore;
using Angelo_Maureira.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar Entity Framework Core con SQL Server
builder.Services.AddDbContext<ComercialSantaClaraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ComercialSantaClaraContext")));

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
