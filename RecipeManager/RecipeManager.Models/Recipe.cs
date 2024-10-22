namespace RecipeManager.Models;
// Defines the Recipe class to represent a single recipe
public class Recipe

{
    public int RecipeId {get; set;}
    // Property to store the name of the recipe
    // Nullable to allow for recipes that might not have a name set yet
    public string? Name { get; set; }

    // List to store the ingredients of the recipe
    // Each ingredient is represented as a string
    public List<string> Ingredients { get; set; }

    // Property to store the cooking instructions
    // Nullable as instructions might not be provided immediately
    public string? Instructions { get; set; }

    // Property to store the cooking time
    // Stored as a string to allow for flexible time formats (e.g., "30 minutes", "1 hour")
    public string CookingTime { get; set; }

    // Property to store the number of servings the recipe makes
    public int Servings { get; set; }

    // Constructor for the Recipe class
    // Initializes the Ingredients list to an empty list
    
    public Recipe()
    {
        Ingredients = [];
    }
}