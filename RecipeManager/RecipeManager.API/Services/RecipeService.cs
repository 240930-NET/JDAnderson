using RecipeManager.API;
using RecipeManager.Data;
using RecipeManager.Models;

namespace RecipeManager.API;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepo _recipeRepo;

    public RecipeService(IRecipeRepo recipeRepo)
    {
        _recipeRepo = recipeRepo ?? throw new ArgumentNullException(nameof(recipeRepo));
    }

    public List<Recipe>? GetAllRecipes()
    {
        var recipes = _recipeRepo.GetAllRecipes();
        return recipes.Any() ? recipes : null;
    }

    public Recipe? GetRecipeById(int id)
    {
        return _recipeRepo.GetRecipeById(id);
    }
}