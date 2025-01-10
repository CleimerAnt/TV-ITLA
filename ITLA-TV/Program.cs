using Application.Repository.IRepository;
using Application.Repository.Repository;
using Application.Servicio;
using Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conexion = builder.Configuration.GetConnectionString("conexion");
//Aplicacion del Repositorio

builder.Services.AddTransient<IGenerosRepository, GenerosRepository>();
builder.Services.AddTransient<IProductoraRepository, ProductoraRepository>();
builder.Services.AddTransient<ISeriesRepository, SeriesRepository>();
builder.Services.AddTransient<ServicioGenero>();
builder.Services.AddTransient<ServicioProductora>();
builder.Services.AddTransient<ServicioSeries>();
builder.WebHost.UseUrls("http://*:5126");
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(conexion);
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.Migrate();   
}

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
    pattern: "{controller=Series}/{action=Index}/{id?}");

app.Run();
