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

    [HttpGet]
    public async Task<IActionResult> GetAllIngredients()
    {
        try
        {
            var ingredients = await _ingredientService.GetAllIngredients();
            return Ok(ingredients);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("getIngredientById/{id}")]
    public async Task<IActionResult> GetIngredientById(int id)
    {
        try
        {
            var ingredient = await _ingredientService.GetIngredientById(id);
            if (ingredient == null)
            {
                return NotFound($"No ingredient found with id {id}"); // Improved not found message
            }
            return Ok(ingredient);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddIngredient([FromBody] IngredientDto ingredientDto)
    {
        try
        {
            var addedIngredient = await _ingredientService.AddIngredient(ingredientDto);
            return Ok(ingredientDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("editIngredient")]
    public async Task<IActionResult> UpdateIngredient([FromBody] IngredientUpdateDto ingredientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDto);
            var updatedIngredient = await _ingredientService.UpdateIngredient(ingredient);
            return Ok(updatedIngredient);
        }
        catch (Exception e)
        {
            return BadRequest($"Could not update ingredient: {e.Message}");
        }
    }

    
}