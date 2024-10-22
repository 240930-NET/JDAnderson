using RecipeManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecipeManager.API;

[ApiController]
[Route("api/[controller]")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
    }

    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetRecipes()
    {
        try
        {
            var recipes = _recipeService.GetAllRecipes();
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
    public IActionResult GetRecipeById(int id) { 
        try { 
            var recipeFound = _recipeService.GetRecipeById(id); 
            if (recipeFound == null) { 
                return NotFound("$Recipe with Id {id} not found."); 
            }
            return Ok(recipeFound); 
        } catch(Exception error) { 
            return StatusCode(500, error.Message);
        }
    }
}