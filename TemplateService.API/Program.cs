using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TemplateService.Application;
using TemplateService.Application.Services;
using TemplateService.Domain;
using TemplateService.Infrastructure;
using TemplateService.Infrastructure.Reposotories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TemplateService API",
        Version = "v1",
        Description = "API для управления комиксами и пользователями",
        Contact = new OpenApiContact
        {
            Name = "Ваше имя",
            Email = "your.email@example.com"
        }
    });
});


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IComicService, ComicService>();
builder.Services.AddScoped<IUserReposotory, UserReposotory>();
builder.Services.AddScoped<IComicReposotory, ComicReposotory>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5000", "https://localhost:5001") // адреса Uno приложения
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<ComicServiceDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ComicServiceDbContext)));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemplateService API v1");
        c.RoutePrefix = "swagger"; // Доступ по /swagger
    });
}

app.UseCors(MyAllowSpecificOrigins);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
