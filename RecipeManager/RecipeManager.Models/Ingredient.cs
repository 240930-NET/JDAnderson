namespace RecipeManager.Models
{
     public class Ingredient
    {
        public int IngredientId { get; set; }
        public required string Name { get; set; }
        public required string Quantity { get; set; }
        public int RecipeId { get; set; }
        
        // Changed from Recipes to Recipe (singular) for clarity
        // Kept as nullable, but consider if it should be required
        public virtual Recipe? Recipe { get; set; }
    }
}