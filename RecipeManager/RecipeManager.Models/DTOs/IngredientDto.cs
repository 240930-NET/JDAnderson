namespace RecipeManager.Models.DTOs;
  public class IngredientDto
    {
        public int IngredientId { get; set; }
        public string Name { get; set; } = ""; 
        public string Quantity { get; set; } = ""; 
    }