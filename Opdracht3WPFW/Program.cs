using Microsoft.EntityFrameworkCore;
using Opdracht3WPFW.Data;
using Opdracht3WPFW.Endpoints;
using Opdracht3WPFW.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<BlogpostService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapProjectEndpoints();
app.MapBlogpostEndpoints();

app.Run();