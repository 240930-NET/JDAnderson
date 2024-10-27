namespace RecipeManager.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public required string Name { get; set; }
        public required string Quantity { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipes { get; set; } // Make this nullable
    }
}