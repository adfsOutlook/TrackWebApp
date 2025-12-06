using Project.Server.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Project.Server.Services;  // Agregado para Swagger

using Project.Server.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();




builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.DictionaryKeyPolicy = null;
    });





// Agregar configuración de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<TrackContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TrackConn")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
    // Agregar Swagger solo en entorno de desarrollo LO PUSE FUERA DEL IF PARA QUE PUEDA VERLO JUAN PABLO
    //app.UseSwagger();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    //    //  c.RoutePrefix = string.Empty; // Cambia este valor para ajustar la URL de Swagger
    //});
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region PONER DENTRO DE IF DE DESARROLLO PARA QUE NO SE MUESTRE EN PRODUCCION
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    //  c.RoutePrefix = string.Empty; // Cambia este valor para ajustar la URL de Swagger
});
#endregion

// Habilitar CORS
app.UseCors("AllowAllOrigins");  // Esto va aquí


app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
