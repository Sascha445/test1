using Opdracht3WPFW.DTOs;
using Opdracht3WPFW.Services;

namespace Opdracht3WPFW.Endpoints;

public static class ProjectEndpoints
{
    public static void MapProjectEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/projecten");

        group.MapGet("/", async (ProjectService service) =>
            Results.Ok(await service.GetAll()));

        group.MapGet("/{id}", async (int id, ProjectService service) =>
        {
            var project = await service.GetById(id);
            return project == null ? Results.NotFound() : Results.Ok(project);
        });

        group.MapPost("/", async (ProjectCreateDto dto, ProjectService service) =>
        {
            var created = await service.Create(dto);
            return Results.Created($"/projecten/{created.Id}", created);
        });

        group.MapPut("/{id}", async (int id, ProjectUpdateDto dto, ProjectService service) =>
        {
            var updated = await service.Update(id, dto);
            return updated == null ? Results.NotFound() : Results.Ok(updated);
        });

        group.MapDelete("/{id}", async (int id, ProjectService service) =>
            await service.Delete(id) ? Results.NoContent() : Results.NotFound());
    }
}