using Microsoft.EntityFrameworkCore;
using RecipeManager.Models;
namespace RecipeManager.Data;


public class RecipeRepo : IRecipeRepo
{
    private readonly RecipeContext _context;

    public RecipeRepo(RecipeContext context)
    {
        _context = context; // holds reference to our context 
    }

    // CRUD Methods 

    public List<Recipe> GetAllRecipes() { 
        return _context.Recipes.ToList(); 
    }

    public Recipe? GetRecipeById(int id) { 
        return _context.Recipes.Find(id);  
    }

    // Implement: 
    // Add new Recipe 
    // Update exisiting recipe 
    // Delete recipe 




}