using RecipeManager.Models;
using RecipeManager.Data;
using RecipeManager.Models.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeManager.API.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepo _ingredientRepo;
    private readonly IMapper _mapper;

    public IngredientService(IIngredientRepo ingredientRepo, IMapper mapper)
    {
        _ingredientRepo = ingredientRepo;
        _mapper = mapper;
    }

    public async Task<Ingredient?> GetIngredientById(int id)
    {
        var ingredient = await _ingredientRepo.GetIngredientById(id);

        // Check if the ingredient was found
        if (ingredient == null)
        {
            throw new Exception($"No ingredient found with id {id}");
        }

        else
        {
            return ingredient;
        }
    }

    public async Task<List<Ingredient>> GetAllIngredients()
    {
        var allIngredients = await _ingredientRepo.GetAllIngredients() ?? new List<Ingredient>();

        // Check if any ingredients were found
        if (allIngredients.Count == 0)
        {
            throw new Exception("No ingredients found");
        }

        return allIngredients;
    }

    public async Task<Ingredient> AddIngredient(IngredientDto ingredientDto)
    {
        // Convert from IngredientDto to Ingredient using AutoMapper
        var ingredient = _mapper.Map<Ingredient>(ingredientDto);

        // Validate the ingredient name
        if (string.IsNullOrEmpty(ingredient.Name))
        {
            throw new Exception("Ingredient name is required");
        }

        return await _ingredientRepo.AddIngredient(ingredient);
    }

    public async Task<Ingredient> UpdateIngredient(Ingredient ingredient) // Accepting Ingredient model
    {
        // Validate that the ingredient exists and that its name is not null
        var existingIngredient = await _ingredientRepo.GetIngredientById(ingredient.IngredientId);

        if (existingIngredient == null || string.IsNullOrEmpty(ingredient.Name))
        {
            throw new Exception($"Invalid input! No ingredient found with id {ingredient.IngredientId} or name is null.");
        }


        // Add any other properties you want to update

        else
        {
            return await _ingredientRepo.UpdateIngredient(existingIngredient);
        }
    }

    public async Task DeleteIngredient(int id)
    {
        var ingredient = await _ingredientRepo.GetIngredientById(id);

        // Check if the ingredient was found before attempting to delete
        if (ingredient == null)
        {
            throw new Exception($"No ingredient found with id {id}");
        }

        await _ingredientRepo.DeleteIngredient(ingredient); // Assuming this method exists
    }
}