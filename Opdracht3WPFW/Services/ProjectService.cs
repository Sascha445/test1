using Microsoft.EntityFrameworkCore;
using Opdracht3WPFW.Data;
using Opdracht3WPFW.DTOs;
using Opdracht3WPFW.Models;

namespace Opdracht3WPFW.Services;

public class ProjectService
{
    private readonly AppDbContext _db;

    public ProjectService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<ProjectResponseDto>> GetAll()
    {
        var projecten = await _db.Projects.ToListAsync();
        return projecten.Select(ToDto).ToList();
    }

    public async Task<ProjectResponseDto?> GetById(int id)
    {
        var project = await _db.Projects.FindAsync(id);
        return project == null ? null : ToDto(project);
    }

    public async Task<ProjectResponseDto> Create(ProjectCreateDto dto)
    {
        var project = new Project
        {
            Titel = dto.Titel,
            Beschrijving = dto.Beschrijving,
            Categorie = dto.Categorie,
            GitHubUrl = dto.GitHubUrl,
            Datum = dto.Datum
        };

        _db.Projects.Add(project);
        await _db.SaveChangesAsync();

        return ToDto(project);
    }

    public async Task<ProjectResponseDto?> Update(int id, ProjectUpdateDto dto)
    {
        var project = await _db.Projects.FindAsync(id);

        if (project == null)
            return null;

        project.Titel = dto.Titel;
        project.Beschrijving = dto.Beschrijving;
        project.Categorie = dto.Categorie;
        project.GitHubUrl = dto.GitHubUrl;
        project.Datum = dto.Datum;

        await _db.SaveChangesAsync();

        return ToDto(project);
    }

    public async Task<bool> Delete(int id)
    {
        var project = await _db.Projects.FindAsync(id);

        if (project == null)
            return false;

        _db.Projects.Remove(project);
        await _db.SaveChangesAsync();

        return true;
    }

    // Enige plek waar een Project-entiteit naar een DTO wordt omgezet
    private static ProjectResponseDto ToDto(Project p) => new()
    {
        Id = p.Id,
        Titel = p.Titel,
        Beschrijving = p.Beschrijving,
        Categorie = p.Categorie,
        GitHubUrl = p.GitHubUrl,
        Datum = p.Datum
    };
}