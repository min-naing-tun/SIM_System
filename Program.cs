using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SIM_System.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Connectin string

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson();

//Dependency Injection

//API optimization
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddResponseCompression();

//Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "/swagger/{documentname}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/v1/swagger.json", "MBL Shipping Import Management System API Services");
    });
    app.UseDeveloperExceptionPage();
}
else if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger(c => {
        c.RouteTemplate = "/swagger/{documentname}/swagger.json";
        c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
        {
            swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" } };
        });
    });

    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint($"/swagger/v1/swagger.json", "MBL Shipping Import Management System API Services");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
