using Clean.Application.Queries.Customer;
using Clean.Infra.Attributes;
using Clean.Infra.Context;
using Clean.Infra.Middlewares;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var cs = configuration.GetConnectionString("SqlServer");

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(cs, x => { x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName); });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clean.API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("allow", policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddServicesFrom(new[]
{
    "Clean.Application",
    "Clean.Infra"
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CustomerQueriesHandler).Assembly));

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
