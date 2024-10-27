using RecipeManager.Models;
using RecipeManager.Models.DTOs;
using System.Threading.Tasks;

namespace RecipeManager.Data
{
    public interface IRecipeRepo
    {
        Task<List<Recipe>> GetAllRecipes(); // Get all recipes
        Task<Recipe?> GetRecipeById(int id); // Get a recipe by ID
        Task<string> AddRecipe(Recipe recipe); // Accept Recipe for adding
        Task UpdateRecipe(Recipe recipe); // Accept Recipe for updating
        Task DeleteRecipe(Recipe recipe); // Accept Recipe for deleting
    }
}