using RecipeManager.Models;
using RecipeManager.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using RecipeManager.API.Services;
using AutoMapper;
namespace RecipeManager.API;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    private readonly IMapper _mapper;

    public RecipeController(IRecipeService recipeService, IMapper mapper)
    {
        _recipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
    {
        try
        {
            var recipes = await _recipeService.GetAllRecipes();
            if (recipes == null || !recipes.Any())
            {
                return NotFound("No recipes found.");
            }
            return Ok(recipes);
        }
        catch (Exception error)
        {
            return StatusCode(500, $"Internal server error: {error.Message}");
        }
    }

    [HttpGet("getRecipeById/{id}")]
    public async Task<IActionResult> GetRecipeById(int id)
    {
        try
        {
            var recipeFound = await _recipeService.GetRecipeById(id);
            if (recipeFound == null)
            {
                return NotFound($"Recipe with Id {id} not found."); // Fixed string interpolation
            }
            return Ok(recipeFound);
        }
        catch (Exception error)
        {
            return StatusCode(500, error.Message);
        }
    }

    // Route to add new Recipe 
    [HttpPost]
    public async Task<IActionResult> AddRecipe([FromBody] RecipeDto recipeDto)
    {
        try
        {
            var resultMessage = await _recipeService.AddRecipe(recipeDto);
            // Return a simple message instead of the created resource
            return Created("", resultMessage); // Return 201 Created with a message
        }
        catch (Exception error)
        {
            return BadRequest($"Could not add recipe: {error.Message}"); // Improved error message
        }
    }

    // Route for editing 
    [HttpPut("editRecipe")]
    public async Task<IActionResult> EditRecipe([FromBody] RecipeDto recipeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);
            var updatedRecipe = await _recipeService.UpdateRecipe(recipe);
            return Ok(updatedRecipe);
        }
        catch (Exception e)
        {
            return BadRequest($"Could not edit recipe: {e.Message}");
        }
    }

    // Route for deleting 
    [HttpDelete("deleteRecipe/{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        try
        {
            await _recipeService.DeleteRecipe(id);
            return NoContent(); // 204 No Content
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); // 404 Not Found
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}