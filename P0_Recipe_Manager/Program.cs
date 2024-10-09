using System.Globalization;
using System.Runtime.InteropServices;

namespace P0_Recipe_Manager;

class Program
{
    static void Main(string[] args)
    {

        List<Recipe> receipesStored = Data.DeserializeRecipes(); 

        UI.AppInfo();

        UI.DisplayOptions();
        int optionPicked = UI.GetChoice();

        while (optionPicked != 9)
        {
            switch (optionPicked)
            {
                case 1:
                    Console.WriteLine("\n\t1: Add a New Recipe");
                    Recipe newRecipe = UI.GetRecipeInfo();
                    RecipeManager.AddRecipe(newRecipe);
                    UI.DisplayRecipe(newRecipe);

                    break;
                case 2:
                    Console.WriteLine("\n\t2: View all recipes");
                    
                    UI.DisplayAllRecipes(receipesStored);
                    break;
                case 3:
                    Console.WriteLine("\n\tSearch Recipes");

                    break;
                case 4:
                    Console.WriteLine("\n\tEdit Recipes");
                
                    break;

                case 5:
                    Console.WriteLine("\n\t5: Delete Recipe");
                    break;
                case 6:
                    Console.WriteLine("\n Save Recipes");
                     RecipeManager.Save(RecipeManager.AllRecipes);
                    break;


                case 9:
                    Console.WriteLine("\n\t9: Exit Application");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            UI.DisplayOptions();
            // Get the next choice
            optionPicked = UI.GetChoice();

        }
    }
}
