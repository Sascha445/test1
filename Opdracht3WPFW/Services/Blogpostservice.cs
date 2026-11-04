using Microsoft.EntityFrameworkCore;
using Opdracht3WPFW.Data;
using Opdracht3WPFW.DTOs;
using Opdracht3WPFW.Models;

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
        return blogposts.Select(ToDto).ToList();
    }

    public async Task<BlogpostResponseDto?> GetById(int id)
    {
        var blogpost = await _db.Blogposts.FindAsync(id);
        return blogpost == null ? null : ToDto(blogpost);
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

        return ToDto(blogpost);
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

        return ToDto(blogpost);
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

    // Enige plek waar een Blogpost-entiteit naar een DTO wordt omgezet
    private static BlogpostResponseDto ToDto(Blogpost b) => new()
    {
        Id = b.Id,
        Titel = b.Titel,
        Inhoud = b.Inhoud,
        Publicatiedatum = b.Publicatiedatum
    };
}