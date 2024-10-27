using Microsoft.EntityFrameworkCore;
using RecipeManager.Models;
using RecipeManager.Models.DTOs;

namespace RecipeManager.Data
{
   public class RecipeRepo : IRecipeRepo
{
    private readonly RecipeContext _context;

    public RecipeRepo(RecipeContext context)
    {
        _context = context;
    }

    public async Task<List<Recipe>> GetAllRecipes()
    {
        return await _context.Recipes.Include(r => r.Ingredients).ToListAsync();
    }

    public async Task<Recipe?> GetRecipeById(int id)
    {
        return await _context.Recipes.Include(r => r.Ingredients).FirstOrDefaultAsync(r => r.RecipeId == id);
    }

    public async Task<string> AddRecipe(Recipe recipe)
    {
        await _context.Recipes.AddAsync(recipe);
        await _context.SaveChangesAsync();
        return $"Recipe '{recipe.Name}' added successfully with ID {recipe.RecipeId}";
    }

    public async Task UpdateRecipe(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRecipe(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();
    }
}
}