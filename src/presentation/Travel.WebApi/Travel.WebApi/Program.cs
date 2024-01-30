using Microsoft.EntityFrameworkCore;
using Travel.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TravelDbContext>(options => options.UseSqlite("DataSource=TravelDatabase.sqlite3"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Travel Web API",
        Version = "v1",
        Description = "PoC Web API using .net 8 clean architecture",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Name = "Suriya S.",
            Email = "suriyasonp.tech@gmail.com"
        },
    });
});

var app = builder.Build();

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
