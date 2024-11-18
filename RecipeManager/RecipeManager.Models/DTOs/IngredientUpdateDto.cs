namespace RecipeManager.Models.DTOs
{
    public class IngredientUpdateDto
    {
        public int IngredientId { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Quantity { get; set; } = string.Empty;
       
    }
}