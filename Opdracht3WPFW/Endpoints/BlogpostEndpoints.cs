using Opdracht3WPFW.DTOs;
using Opdracht3WPFW.Services;

namespace Opdracht3WPFW.Endpoints;

public static class BlogpostEndpoints
{
    public static void MapBlogpostEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/blogposts");

        group.MapGet("/", async (BlogpostService service) =>
            Results.Ok(await service.GetAll()));

        group.MapGet("/{id}", async (int id, BlogpostService service) =>
        {
            var blogpost = await service.GetById(id);
            return blogpost == null ? Results.NotFound() : Results.Ok(blogpost);
        });

        group.MapPost("/", async (BlogpostCreateDto dto, BlogpostService service) =>
        {
            var created = await service.Create(dto);
            return Results.Created($"/blogposts/{created.Id}", created);
        });

        group.MapPut("/{id}", async (int id, BlogpostUpdateDto dto, BlogpostService service) =>
        {
            var updated = await service.Update(id, dto);
            return updated == null ? Results.NotFound() : Results.Ok(updated);
        });

        group.MapDelete("/{id}", async (int id, BlogpostService service) =>
            await service.Delete(id) ? Results.NoContent() : Results.NotFound());
    }
}