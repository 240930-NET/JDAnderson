
namespace RecipeManager.Models.DTOs;
public class RecipeUpdateDto
{
    public int RecipeId { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Instructions { get; set; } = string.Empty;
    public required string CookingTime { get; set; } = string.Empty;
    public int Servings { get; set; }
}