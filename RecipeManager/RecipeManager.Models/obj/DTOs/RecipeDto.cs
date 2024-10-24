namespace RecipeManager.Models.DTOs;

public class RecipeDto {  public string? Name { get; set; }

    public string? Instructions { get; set; }

    public string CookingTime { get; set; } = string.Empty;

    public int Servings { get; set; }

    public List<Ingredient>? Ingredients {get; set;}


}