using System.ComponentModel.DataAnnotations;

namespace ShareModel.DTO.Rating;

public class ReviewProductFormDTO
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Star { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
}