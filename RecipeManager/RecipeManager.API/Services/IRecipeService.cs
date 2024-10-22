namespace RecipeManager.API;
using RecipeManager.Data; 
using RecipeManager.Models; 
// additional layer between business logic and controllers and our data 
public interface IRecipeService
{
    List<Recipe>? GetAllRecipes();
    Recipe? GetRecipeById(int id);
}