using Microsoft.EntityFrameworkCore;
using Opdracht3WPFW.Data;
using Opdracht3WPFW.Models;
using Opdracht3WPFW.DTOs;

namespace Opdracht3WPFW.Services;

public class BlogpostService
{
    private readonly AppDbContext _db;

    public BlogpostService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<BlogpostResponseDto>> GetAll()
    {
        var blogposts = await _db.Blogposts.ToListAsync();

        return blogposts.Select(b => new BlogpostResponseDto
        {
            Id = b.Id,
            Titel = b.Titel,
            Inhoud = b.Inhoud,
            Publicatiedatum = b.Publicatiedatum
        }).ToList();
    }

    public async Task<BlogpostResponseDto?> GetById(int id)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);

        if (blogpost == null)
            return null;

        return new BlogpostResponseDto
        {
            Id = blogpost.Id,
            Titel = blogpost.Titel,
            Inhoud = blogpost.Inhoud,
            Publicatiedatum = blogpost.Publicatiedatum
        };
    }

    public async Task<BlogpostResponseDto> Create(BlogpostCreateDto dto)
    {
        var blogpost = new Blogpost
        {
            Titel = dto.Titel,
            Inhoud = dto.Inhoud,
            Publicatiedatum = dto.Publicatiedatum
        };

        _db.Blogposts.Add(blogpost);
        await _db.SaveChangesAsync();

        return await GetById(blogpost.Id) ?? throw new Exception("Blogpost niet gevonden.");
    }

    public async Task<BlogpostResponseDto?> Update(int id, BlogpostUpdateDto dto)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);

        if (blogpost == null)
            return null;

        blogpost.Titel = dto.Titel;
        blogpost.Inhoud = dto.Inhoud;
        blogpost.Publicatiedatum = dto.Publicatiedatum;

        await _db.SaveChangesAsync();

        return await GetById(id);
    }

    public async Task<bool> Delete(int id)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);

        if (blogpost == null)
            return false;

        _db.Blogposts.Remove(blogpost);
        await _db.SaveChangesAsync();

        return true;
    }
}