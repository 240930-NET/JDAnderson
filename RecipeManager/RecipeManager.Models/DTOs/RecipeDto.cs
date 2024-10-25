namespace RecipeManager.Models.DTOs;

 public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string Name { get; set; } = "";
        public string Instructions { get; set; } = ""; 
        public string CookingTime { get; set; } = ""; 
        public int Servings { get; set; }
        public List<IngredientDto> Ingredients { get; set; } = new List<IngredientDto>();
    }