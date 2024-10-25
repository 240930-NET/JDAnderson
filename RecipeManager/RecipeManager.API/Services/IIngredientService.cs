using RecipeManager.Models;
using RecipeManager.Data;
using RecipeManager.Models.DTOs;

namespace RecipeManager.API.Services;

public interface IIngredientService
{
    Task<Ingredient?> GetIngredientById(int id);
    Task<List<Ingredient>> GetIngredients();

    // This should not be user correct 
    /* 
    ################################$############endregion
    */
    public Task<Ingredient> AddIngredient(IngredientDto ingredient);
    public Task<Ingredient> UpdateIngredient(Ingredient ingredient);

    /* 
    ################################$############endregion
    */
    public Task DeleteIngredient(int id);
}