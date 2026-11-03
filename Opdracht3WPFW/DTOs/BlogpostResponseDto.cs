namespace Opdracht3WPFW.DTOs;

public class BlogpostResponseDto
{
    public int Id { get; set; }
    public string Titel { get; set; } = "";
    public string Inhoud { get; set; } = "";
    public DateTime Publicatiedatum { get; set; }
}