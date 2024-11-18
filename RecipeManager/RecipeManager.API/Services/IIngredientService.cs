namespace RecipeManager.API.Services;

using RecipeManager.Models;
using RecipeManager.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

// Interface for ingredient service
public interface IIngredientService
{
	Task<Ingredient?> GetIngredientById(int id);
	Task<List<Ingredient>> GetAllIngredients();

	Task<Ingredient> AddIngredient(IngredientDto ingredient); // Accepting IngredientDto just what the use needs to add 
	Task<Ingredient> UpdateIngredient(Ingredient ingredient); // Updated to accept IngredientDto

	Task DeleteIngredient(int id);
	Task<List<Ingredient>> AddMultipleIngredients(int recipeId, List<IngredientDto> ingredients);
}