using System.Text;

class RecipeManager
{
    // Method to get multi-line input from the user
    public static string GetMultlineInput()
    {
        StringBuilder userInfoType = new();
        string? line;
        while (true)
        {
            line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                break; // Exit loop if line is empty or whitespace
            }
            else
            {
                userInfoType.AppendLine(line); // Add non-empty lines to the StringBuilder
            }
        }
        return userInfoType.ToString().Trim(); // Return the combined input, trimmed of leading/trailing whitespace
    }

    // Method to parse a comma-separated string of ingredients into a list
    public static List<string> ParseIngredients(string ingredientsInput)
    {
        var ingredients = new List<string>();
        string[] IngredientsSplit = ingredientsInput.Split(",");
        foreach (string ingredient in IngredientsSplit)
        {
            string ingredientTrimmed = ingredient.Trim();
            if (!string.IsNullOrWhiteSpace(ingredientTrimmed))
            {
                ingredients.Add(ingredientTrimmed); // Add non-empty ingredients to the list
            }
        }
        return ingredients;
    }

    // Method to add a new recipe to the list
    public static void AddRecipe(List<Recipe>? recipesList, Recipe newRecipe)
    {
        if (recipesList == null)
        {
            throw new ArgumentNullException(nameof(recipesList), "Recipe list cannot be null.");
        }
        recipesList.Add(newRecipe);
    }

    // Asynchronous method to save the recipe list
    public static async void Save(List<Recipe> recipe)
    {
        await Data.AsyncSerializeData(recipe);
    }

    // Method to remove a recipe from the list
    public static void RemoveRecipe(List<Recipe>? recipeList)
    {
        if (recipeList == null || recipeList.Count == 0)
        {
            Console.WriteLine("No recipes available to remove.");
            return;
        }

        Console.Write("Enter the name of the recipe you want to remove: ");
        string? recipeNameToRemove = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(recipeNameToRemove))
        {
            Console.WriteLine("Invalid recipe name.");
            return;
        }

        // Find the recipe to delete, ignoring case and trimming whitespace
        var recipeToDelete = recipeList.Find(recipe => 
            string.Equals(recipe.Name?.Trim(), recipeNameToRemove, StringComparison.OrdinalIgnoreCase));
        
        if (recipeToDelete != null)
        {
            recipeList.Remove(recipeToDelete); // Remove the recipe from the list
            Console.WriteLine($"Recipe '{recipeToDelete.Name.Trim()}' was removed successfully.");

            // Save the updated list to the file
            Save(recipeList);
            Console.WriteLine("Recipe list updated and saved to file.");
        }
        else
        {
            Console.WriteLine($"The recipe '{recipeNameToRemove}' was not found.");
            Console.WriteLine("Try pressing 2 to view all recipes, then try again.");
        }
    }
}