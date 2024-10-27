namespace RecipeManager.Models.DTOs
{
    public class IngredientDto
    {
        public required string Name { get; set; }
        public required string Quantity { get; set; }
        public int RecipeId { get; set; } // Foreign key to associate with a recipe
    }
}