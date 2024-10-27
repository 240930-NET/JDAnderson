using RecipeManager.Models;
using RecipeManager.Models.DTOs;

namespace RecipeManager.Data
{
    public interface IIngredientRepo
    {
        Task<List<Ingredient>> GetAllIngredients(); // Get all ingredients
        Task<Ingredient>? GetIngredientById(int id); // Get an ingredient by ID
        Task<Ingredient> AddIngredient(Ingredient ingredient); // Accept IngredientDto for adding
        Task<Ingredient> UpdateIngredient(Ingredient ingredient); // Accept IngredientDto for updating
        Task DeleteIngredient(Ingredient ingredient); // Accept ID for deleting an ingredient
    }
}