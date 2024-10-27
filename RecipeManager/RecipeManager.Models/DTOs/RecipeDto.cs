namespace RecipeManager.Models.DTOs
{
    public class RecipeDto
    {
        public string Name { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string CookingTime { get; set; } = string.Empty;
        public int Servings { get; set; }
    }
}