using RecipeManager.Models.DTOs;
using RecipeManager.Models; 
using Microsoft.AspNetCore.Mvc;
using RecipeManager.API.Services;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace RecipeManager.API.Controllers;

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
    public ActionResult<IEnumerable<RecipeDto>> GetRecipes()
    {
        try
        {
            var recipes = _recipeService.GetAllRecipes();
            if (recipes == null || !recipes.Any())
            {
                return NotFound("No recipes found.");
            }
            var recipeDtos = _mapper.Map<IEnumerable<RecipeDto>>(recipes);
            return Ok(recipeDtos);
        }
        catch (Exception error)
        {
            return StatusCode(500, $"Internal server error: {error.Message}");
        }
    }

    [HttpGet("getRecipeById/{id}")]
    public IActionResult GetRecipeById(int id)
    {
        try
        {
            var recipeFound = _recipeService.GetRecipeById(id);
            if (recipeFound == null)
            {
                return NotFound($"Recipe with Id {id} not found.");
            }
            var recipeDto = _mapper.Map<RecipeDto>(recipeFound);
            return Ok(recipeDto);
        }
        catch (Exception error)
        {
            return StatusCode(500, $"Internal server error: {error.Message}");
        }
    }

    [HttpPost]
    public IActionResult AddRecipe([FromBody] RecipeDto recipeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);
            _recipeService.AddRecipe(recipe);
            var createdRecipeDto = _mapper.Map<RecipeDto>(recipe);
            return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.RecipeId }, createdRecipeDto);
        }
        catch (Exception error)
        {
            return BadRequest($"Could not add recipe: {error.Message}");
        }
    }

    [HttpPut("editRecipe/{id}")]
    public IActionResult EditRecipe(int id, [FromBody] RecipeDto recipeDto)
    {
        if (id != recipeDto.RecipeId)
        {
            return BadRequest("Recipe ID mismatch");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var recipe = _mapper.Map<Recipe>(recipeDto);
            _recipeService.EditRecipe(recipe);
            return Ok("Recipe updated successfully");
        }
        catch (Exception error)
        {
            return BadRequest($"Could not edit recipe: {error.Message}");
        }
    }
    
    [HttpDelete("deleteRecipe/{id}")]
    public IActionResult DeleteRecipe(int id)
    { 
        try
        {
            _recipeService.DeleteRecipe(id);
            return Ok("Recipe deleted successfully");
        }
        catch (Exception error)
        {
            return BadRequest($"Could not delete recipe: {error.Message}");
        }
    }
}