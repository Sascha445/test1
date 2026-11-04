using Microsoft.EntityFrameworkCore;
using Opdracht3WPFW.Data;
using Opdracht3WPFW.DTOs;
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

// ---------- Projecten ----------
app.MapGet("/projecten", async (ProjectService service) =>
    Results.Ok(await service.GetAll()));

app.MapGet("/projecten/{id}", async (int id, ProjectService service) =>
{
    var project = await service.GetById(id);
    return project == null ? Results.NotFound() : Results.Ok(project);
});

app.MapPost("/projecten", async (ProjectCreateDto dto, ProjectService service) =>
{
    var created = await service.Create(dto);
    return Results.Created($"/projecten/{created.Id}", created);
});

app.MapPut("/projecten/{id}", async (int id, ProjectUpdateDto dto, ProjectService service) =>
{
    var updated = await service.Update(id, dto);
    return updated == null ? Results.NotFound() : Results.Ok(updated);
});

app.MapDelete("/projecten/{id}", async (int id, ProjectService service) =>
    await service.Delete(id) ? Results.NoContent() : Results.NotFound());

// ---------- Blogposts ----------
app.MapGet("/blogposts", async (BlogpostService service) =>
    Results.Ok(await service.GetAll()));

app.MapGet("/blogposts/{id}", async (int id, BlogpostService service) =>
{
    var blogpost = await service.GetById(id);
    return blogpost == null ? Results.NotFound() : Results.Ok(blogpost);
});

app.MapPost("/blogposts", async (BlogpostCreateDto dto, BlogpostService service) =>
{
    var created = await service.Create(dto);
    return Results.Created($"/blogposts/{created.Id}", created);
});

app.MapPut("/blogposts/{id}", async (int id, BlogpostUpdateDto dto, BlogpostService service) =>
{
    var updated = await service.Update(id, dto);
    return updated == null ? Results.NotFound() : Results.Ok(updated);
});

app.MapDelete("/blogposts/{id}", async (int id, BlogpostService service) =>
    await service.Delete(id) ? Results.NoContent() : Results.NotFound());

app.Run();