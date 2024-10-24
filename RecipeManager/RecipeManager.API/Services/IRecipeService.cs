namespace RecipeManager.API;
using RecipeManager.Data; 
using RecipeManager.Models; 
using RecipeManager.Models.DTOs; 
// additional layer between business logic and controllers and our data 
public interface IRecipeService
{
    List<Recipe>? GetAllRecipes();
    Recipe? GetRecipeById(int id);

     // Add new Recipe
    public string AddRecipe(Recipe recipe);

    // Update Recipe
    public Recipe EditRecipe(Recipe recipe);

    // Delete Recipe
    public string DeleteRecipe(int id);
}