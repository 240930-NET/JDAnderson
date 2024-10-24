namespace RecipeManager.Data;
using RecipeManager.Models;

public interface IRecipeRepo
{
    List<Recipe> GetAllRecipes();

    Recipe? GetRecipeById(int id);

    void AddRecipe(Recipe recipe);

    void DeleteRecipe(Recipe recipe);

    void UpdateRecipe(Recipe recipe);
}