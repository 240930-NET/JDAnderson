namespace RecipeManager.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string? Name { get; set; }
        public string? Instructions { get; set; }
        public string? CookingTime { get; set; }
        public int Servings { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }

   
}