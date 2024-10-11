using System.Globalization;
using System.Runtime.InteropServices;

namespace P0_Recipe_Manager;

class Program
{
    static void Main(string[] args)
    {
        // Load existing recipes from file
        List<Recipe> receipesStored = Data.DeserializeRecipes();

        // Display application information
        UI.AppInfo();

        // Display menu options
        UI.DisplayOptions();
        // Get user's initial choice
        int optionPicked = UI.GetChoice();

        // Main application loop
        while (optionPicked != 9) // 9 is the exit option
        {
            switch (optionPicked)
            {
                case 1:
                    // Add a new recipe
                    Console.WriteLine("\n\t1: Add a New Recipe");
                    Recipe newRecipe = UI.GetRecipeInfo();
                    RecipeManager.AddRecipe(receipesStored, newRecipe);
                    UI.DisplayRecipe(newRecipe);
                    break;

                case 2:
                    // Display all recipes
                    UI.DisplayAllRecipes(receipesStored);
                    break;

                case 3:
                    // Save recipes to file
                    if (receipesStored != null && receipesStored.Count > 0)
                    {
                        RecipeManager.Save(receipesStored);
                        Console.WriteLine("Recipes saved successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No recipes to save. The recipe list is empty.");
                    }
                    break;

                case 4:
                    // Delete a recipe
                    Console.WriteLine("\n\t4: Delete Recipe");
                    RecipeManager.RemoveRecipe(receipesStored);
                    break;

                case 9:
                    // Exit application
                    Console.WriteLine("\n\t9: Exit Application");
                    break;

                default:
                    // Handle invalid options
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            // Display menu options again
            UI.DisplayOptions();
            // Get the next user choice
            optionPicked = UI.GetChoice();
        }
    }
}