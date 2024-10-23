namespace RecipeManager.Models;

public class Recipe
{
    public int RecipeId { get; set; }

    public string? Name { get; set; }

    public string? Instructions { get; set; }

    public string CookingTime { get; set; } = string.Empty;

    public int Servings { get; set; }

    public List<Ingredient> Ingredients {get; set;}

    // This property is not in the database table
    // public List<string> Ingredients { get; set; }

    public Recipe()
    {
        Ingredients = [];
    }
}