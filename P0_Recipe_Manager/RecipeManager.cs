
using System.Text;
class RecipeManager
{
    public static List<Recipe> AllRecipes = []; 
    public static string getMultlineInput()
    {
        StringBuilder userInfoType = new();
        string? line;
        while (true)
        {
            line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                break;

            }
            else
            {
                userInfoType.AppendLine(line);
            }
        }
        return userInfoType.ToString().Trim();

    }
    public static List<string> ParseIngredients(string ingredientsInput)
    {
        var ingredients = new List<string>();
        string[] IngredientsSplit = ingredientsInput.Split(",");
        foreach (string ingredient in IngredientsSplit)
        {
            string ingredientTrimmed = ingredient.Trim();
            if (!string.IsNullOrWhiteSpace(ingredientTrimmed))
            {
                ingredients.Add(ingredientTrimmed);
            }
        }
        return ingredients;

    }

    public static void AddRecipe(Recipe recipe) { 
        AllRecipes.Add(recipe); 
    }


   
}