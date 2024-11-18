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
		if (ingredientDto == null)
		{
			throw new ArgumentNullException(nameof(ingredientDto));
		}

		// Convert from IngredientDto to Ingredient using AutoMapper
		var ingredient = _mapper.Map<Ingredient>(ingredientDto);

		// Validate the ingredient name
		if (string.IsNullOrEmpty(ingredient.Name))
		{
			throw new ArgumentException("Ingredient name is required");
		}

		return await _ingredientRepo.AddIngredient(ingredient);
	}

	public async Task<Ingredient> UpdateIngredient(Ingredient ingredient)
	{
		var existingIngredient = await _ingredientRepo.GetIngredientById(ingredient.IngredientId);
		if (existingIngredient == null)
		{
			throw new KeyNotFoundException($"Ingredient with ID {ingredient.IngredientId} not found");
		}

		existingIngredient.Name = ingredient.Name;
		existingIngredient.Quantity = ingredient.Quantity;
		existingIngredient.RecipeId = ingredient.RecipeId;

		await _ingredientRepo.UpdateIngredient(existingIngredient);
		return existingIngredient;
	}

	public async Task DeleteIngredient(int id)
	{
		var ingredient = await _ingredientRepo.GetIngredientById(id);
		if (ingredient == null)
		{
			throw new KeyNotFoundException($"Ingredient with ID {id} not found.");
		}

		await _ingredientRepo.DeleteIngredient(ingredient);
	}

	public async Task<List<Ingredient>> AddMultipleIngredients(int recipeId, List<IngredientDto> ingredientDtos)
    {
        if (ingredientDtos == null || ingredientDtos.Count == 0)
        {
            throw new ArgumentException("No ingredients provided");
        }

        var ingredients = new List<Ingredient>();

        foreach (var dto in ingredientDtos)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                throw new ArgumentException("Ingredient name is required");
            }

            var ingredient = _mapper.Map<Ingredient>(dto);
            ingredient.RecipeId = recipeId; // Set recipeId from the route parameter
            ingredients.Add(ingredient);
        }

        return await _ingredientRepo.AddMultipleIngredients(ingredients);
    }
}