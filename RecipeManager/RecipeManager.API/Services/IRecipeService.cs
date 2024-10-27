using RecipeManager.Models;
using RecipeManager.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeManager.API.Services
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetAllRecipes();
        Task<Recipe?> GetRecipeById(int id);
        Task<string> AddRecipe(RecipeDto recipeDto);
        Task<Recipe> UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(int id);
    }
}