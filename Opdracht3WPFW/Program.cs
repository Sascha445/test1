using Microsoft.EntityFrameworkCore;
using Opdracht3WPFW.Data;

var builder = WebApplication.CreateBuilder(args);

// Databaseverbinding
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Run();