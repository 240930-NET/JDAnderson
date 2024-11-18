namespace RecipeManager.Models.DTOs; 
public class MultipleIngredientsDto
{
 public int RecipeId { get; set; }
    public List<IngredientDto> Ingredients { get; set; }
}