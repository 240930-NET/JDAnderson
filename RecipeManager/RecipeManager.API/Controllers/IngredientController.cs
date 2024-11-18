using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using RecipeManager.Models;
using RecipeManager.API.Services;
using RecipeManager.Models.DTOs; // Ensure this namespace is included

namespace RecipeManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
	private readonly IIngredientService _ingredientService;
	private readonly IMapper _mapper;

	public IngredientController(IIngredientService ingredientService, IMapper mapper)
	{
		_ingredientService = ingredientService;
		_mapper = mapper;
	}




	[HttpPost("addMultiple/{recipeId}")]
	public async Task<IActionResult> AddMultipleIngredients(int recipeId, [FromBody] List<IngredientDto> ingredients)
	{
		try
		{
			// Call the service method with recipeId and ingredients
			var addedIngredients = await _ingredientService.AddMultipleIngredients(recipeId, ingredients);
			return Ok(_mapper.Map<List<IngredientDto>>(addedIngredients));
		}
		catch (ArgumentException e)
		{
			return BadRequest(e.Message);
		}
		catch (Exception e)
		{
			// Log the exception
			return StatusCode(500, "An error occurred while processing your request.");
		}
	}
	[HttpPut("editIngredients/{recipeId}")]
	public async Task<IActionResult> UpdateMultipleIngredients(int recipeId, [FromBody] List<IngredientUpdateDto> ingredients)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		try
		{
			// Ensure that the ingredients list is not null or empty
			if (ingredients == null || !ingredients.Any())
			{
				return BadRequest("No ingredients provided.");
			}

			var updatedIngredients = new List<Ingredient>();

			foreach (var ingredientDto in ingredients)
			{
				// Map DTO to Ingredient entity
				var ingredient = _mapper.Map<Ingredient>(ingredientDto);
				ingredient.RecipeId = recipeId; // Set the Recipe ID from the route parameter

				// Call service method to update each ingredient
				var updatedIngredient = await _ingredientService.UpdateIngredient(ingredient);
				updatedIngredients.Add(updatedIngredient);
			}

			return Ok(updatedIngredients); // Return the list of updated ingredients
		}
		catch (KeyNotFoundException e)
		{
			return NotFound(e.Message); // Handle not found case for any ingredient
		}
		catch (Exception e)
		{
			return BadRequest($"Could not update ingredients: {e.Message}"); // Handle other exceptions
		}
	}

}