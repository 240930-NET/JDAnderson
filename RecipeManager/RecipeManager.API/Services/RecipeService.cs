using RecipeManager.Models;
using RecipeManager.Models.DTOs;
using RecipeManager.Data;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeManager.API.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepo _recipeRepo;
        private readonly IMapper _mapper;

        private readonly IIngredientService _ingredientService;
        private readonly ILogger<RecipeService> _logger;

        public RecipeService(IRecipeRepo recipeRepo, IIngredientService ingredientService, ILogger<RecipeService> logger)
        {
            _recipeRepo = recipeRepo;
            _ingredientService = ingredientService;
            _logger = logger;
        }


        public async Task<List<Recipe>> GetAllRecipes()
        {
            var recipes = await _recipeRepo.GetAllRecipes();
            if (recipes == null || recipes.Count == 0)
            {
                throw new Exception("No recipes found");
            }
            return recipes;
        }

        public async Task<Recipe?> GetRecipeById(int id)
        {
            var recipe = await _recipeRepo.GetRecipeById(id);
            return recipe;
        }

        public async Task<string> AddRecipe(RecipeDto recipeDto)
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);
            if (string.IsNullOrEmpty(recipe.Name))
            {
                throw new Exception("Recipe Name required");
            }
            return await _recipeRepo.AddRecipe(recipe);
        }

        public async Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            var searchedRecipe = await _recipeRepo.GetRecipeById(recipe.RecipeId);
            if (searchedRecipe == null)
            {
                throw new KeyNotFoundException($"Recipe with id {recipe.RecipeId} not found");
            }

            if (string.IsNullOrEmpty(recipe.Name))
            {
                throw new ArgumentException("Invalid recipe. Please check name!");
            }

            // Update recipe properties
            searchedRecipe.Name = recipe.Name;
            searchedRecipe.Instructions = recipe.Instructions;
            searchedRecipe.CookingTime = recipe.CookingTime;
            searchedRecipe.Servings = recipe.Servings;

            // Handle ingredients
            searchedRecipe.Ingredients.Clear();
            foreach (var ingredient in recipe.Ingredients)
            {
                searchedRecipe.Ingredients.Add(new Ingredient
                {
                    Name = ingredient.Name,
                    Quantity = ingredient.Quantity,
                    RecipeId = searchedRecipe.RecipeId
                });
            }

            await _recipeRepo.UpdateRecipe(searchedRecipe);
            return searchedRecipe;
        }

        public async Task DeleteRecipe(int id)
        {
            var searchedRecipe = await _recipeRepo.GetRecipeById(id);
            if (searchedRecipe == null)
            {
                throw new KeyNotFoundException($"Recipe with id {id} does not exist");
            }

            try
            {
                var ingredients = await _ingredientService.GetAllIngredients();
                var recipeIngredients = ingredients.Where(i => i.RecipeId == id).ToList();

                foreach (var ingredient in recipeIngredients)
                {
                    try
                    {
                        await _ingredientService.DeleteIngredient(ingredient.IngredientId);
                    }
                    catch (KeyNotFoundException ex)
                    {
                        // Log that the ingredient was not found, but continue with the deletion
                        _logger.LogWarning($"Ingredient with ID {ingredient.IngredientId} not found during recipe deletion: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        // Log any other unexpected errors during ingredient deletion
                        _logger.LogError($"Error deleting ingredient with ID {ingredient.IngredientId}: {ex.Message}");
                        throw new Exception($"An error occurred while deleting an ingredient: {ex.Message}", ex);
                    }
                }

                await _recipeRepo.DeleteRecipe(searchedRecipe);
                _logger.LogInformation($"Recipe with ID {id} and its ingredients successfully deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting recipe with ID {id}: {ex.Message}");
                throw new Exception($"An error occurred while deleting the recipe: {ex.Message}", ex);
            }
        }
    }
}