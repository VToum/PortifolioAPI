using PortifolioWeb.Helper;
using PortifolioWeb.Models;
using PortifolioWeb.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IPortifolioService, PortifolioService>();
builder.Services.AddScoped<IPortifolioService, PortifolioService>();
builder.Services.AddScoped<IEmail, Email>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/IndexPortifolio/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Portifolio}/{action=IndexPortifolio}/{id?}");

app.Run();
