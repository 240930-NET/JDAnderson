using RecipeManager.API;
using RecipeManager.Data;
using RecipeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

    // Add new Recipe
    public string AddRecipe(Recipe recipe)
    {
        if (!string.IsNullOrEmpty(recipe.Name))
        {
            _recipeRepo.AddRecipe(recipe);
            return $"Recipe '{recipe.Name}' added successfully!";
        }
        else
        {
            throw new ArgumentException("Invalid Recipe. Please provide a name!");
        }
    }

    // Update Recipe
    public Recipe EditRecipe(Recipe recipe)
    {
        var existingRecipe = _recipeRepo.GetRecipeById(recipe.RecipeId);
        if (existingRecipe != null)
        {
            if (!string.IsNullOrEmpty(recipe.Name))
            {
                existingRecipe.Name = recipe.Name;
                existingRecipe.Instructions = recipe.Instructions;
                existingRecipe.CookingTime = recipe.CookingTime;
                existingRecipe.Servings = recipe.Servings;
                existingRecipe.Ingredients = recipe.Ingredients;

                _recipeRepo.UpdateRecipe(existingRecipe);
                return existingRecipe;
            }
            else
            {
                throw new ArgumentException("Invalid Recipe. Please provide a name!");
            }
        }

        throw new KeyNotFoundException($"Recipe with id {recipe.RecipeId} does not exist.");
    }

    // Delete Recipe
    public string DeleteRecipe(int id)
    {
        var recipe = _recipeRepo.GetRecipeById(id);
        if (recipe != null)
        {
            _recipeRepo.DeleteRecipe(recipe);
            return $"Recipe with id {id} deleted successfully!";
        }
        else
        {
            throw new KeyNotFoundException($"Recipe with id {id} does not exist");
        }
    }
}