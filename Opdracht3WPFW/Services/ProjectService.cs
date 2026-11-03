using Microsoft.EntityFrameworkCore;
using Opdracht3WPFW.Data;
using Opdracht3WPFW.Models;
using Opdracht3WPFW.DTOs;

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

        return projecten.Select(p => new ProjectResponseDto
        {
            Id = p.Id,
            Titel = p.Titel,
            Beschrijving = p.Beschrijving,
            Categorie = p.Categorie,
            GitHubUrl = p.GitHubUrl,
            Datum = p.Datum
        }).ToList();
    }

    public async Task<ProjectResponseDto?> GetById(int id)
    {
        var project = await _db.Projects.FindAsync(id);

        if (project == null)
            return null;

        return new ProjectResponseDto
        {
            Id = project.Id,
            Titel = project.Titel,
            Beschrijving = project.Beschrijving,
            Categorie = project.Categorie,
            GitHubUrl = project.GitHubUrl,
            Datum = project.Datum
        };
    }

    public async Task<ProjectResponseDto> Create(ProjectDto dto)
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

        return await GetById(project.Id) ?? throw new Exception("Project niet gevonden.");
    }

    public async Task<ProjectResponseDto?> Update(int id, ProjectDto dto)
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

        return await GetById(id);
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
}