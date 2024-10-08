using System.Text;

class UI
{

    public static void AppInfo()
    {
        Console.WriteLine("hello friend welcome to your own a recipe manager appication!");
        Console.WriteLine("Choose on of the options:\n ");
    }
    public static void DisplayOptions()
    {

        Console.WriteLine("\t1: Add a New Recipe");
        Console.WriteLine("\t2: View all recipes");
        Console.WriteLine("\t3: Search Recipes");
        Console.WriteLine("\t4: Edit Recipe");
        Console.WriteLine("\t5: Delete Recipe");
        Console.WriteLine("\t6: Save Recipes"); 
        Console.WriteLine("\t9: Exit Application");
    }


    // method that returns the value that the user enters 
    public static int GetChoice()
    {
        string? userInput = Console.ReadLine();

        try
        {
            int userValue = int.Parse(userInput);
            return userValue;
        }
        catch (Exception error)
        {
            Console.Write(error.Message);
            return 0;
        }
        finally
        {
            Console.WriteLine("this always runs!");
        }
    }

    public static Recipe GetRecipeInfo()
    {

        Console.Write("Type recipe name: ");
        string? recipeName = Console.ReadLine();

        Console.Write("Enter the cooking time (in minutes): ");
        string cookingTime = Console.ReadLine() ?? "0";

        Console.Write("Number of Servings: ");
        int servings = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Enter the instructions (press the enter key when done)");
        string instructions = RecipeManager.getMultlineInput();

        Console.Write("Enter ingredients (comma-separated e.g. '2 cups of flour, 1 tsp of salt'):");
        string ingredientsEntered = Console.ReadLine() ?? "";

        var recipe = new Recipe()
        {
            Name = recipeName,
            Instructions = instructions,
            CookingTime = cookingTime,
            Servings = servings,
            Ingredients = RecipeManager.ParseIngredients(ingredientsEntered)
        };
        return recipe;
    }

    public static void DisplayRecipe(Recipe recipe)
    {
        
        Console.WriteLine("New recipe was added!!\n\n");
        Console.WriteLine("Recipe Information Below\n");
        Console.WriteLine($"Name: {recipe.Name}");
        Console.WriteLine($"Cooking Time: {recipe.CookingTime} ");
        Console.WriteLine($"Servings: {recipe.Servings}");
        foreach (var ingredient in recipe.Ingredients)
        {
            Console.WriteLine($"o {ingredient}");
        }
        Console.WriteLine($"Instructions\n {recipe.Instructions}");
    }

    public static void DisplayAllRecipes()
    {
        if (RecipeManager.AllRecipes.Count == 0)
        {
            Console.WriteLine("\n\nNo Recipes have been entered.\n In order to view recipes please enter option again  to enter a receipe\n\n");
        }
        else
        {
            int recipeNum = 1;

            foreach (Recipe recipe in RecipeManager.AllRecipes)
            {
                Console.WriteLine($"Recipe {recipeNum}\n");
                DisplayRecipe(recipe);
                Console.WriteLine();

                recipeNum++; 
            }
        }
    }



}
