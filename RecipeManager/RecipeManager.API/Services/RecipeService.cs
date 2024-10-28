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

        public RecipeService(IRecipeRepo recipeRepo, IIngredientService ingredientService, ILogger<RecipeService> logger, IMapper mapper)
        {
            _recipeRepo = recipeRepo;
            _ingredientService = ingredientService;
            _logger = logger;
            _mapper = mapper;
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
            var recipe = _mapper.Map<Recipe>(recipeDto); // This will map the DTO to the Recipe model

            if (string.IsNullOrEmpty(recipe.Name))
            {
                throw new Exception("Recipe Name required");
            }

            // Call the repository method to add the recipe
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
                    catch (KeyNotFoundException)
                    {
                        // Log that the ingredient was not found, but continue with the deletion
                        Console.WriteLine($"Ingredient with ID {ingredient.IngredientId} not found during recipe deletion. Continuing...");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting ingredient with ID {ingredient.IngredientId}: {ex.Message}. Continuing...");
                    }
                }

                await _recipeRepo.DeleteRecipe(searchedRecipe);
                Console.WriteLine($"Recipe with ID {id} successfully deleted.");
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the recipe: {ex.Message}", ex);
            }
        }
    }
}