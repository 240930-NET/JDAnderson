namespace RecipeManager.Models.DTOs
{
    public class RecipeDto
    {
     
        public required string Name { get; set; } = string.Empty;
        public required string Instructions { get; set; } = string.Empty;
        public required string CookingTime { get; set; } = string.Empty;
        public int Servings { get; set; }
    }
}