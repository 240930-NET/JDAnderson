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

    public List<Recipe> GetAllRecipes()
    {
        return _context.Recipes.ToList();
    }

    public Recipe? GetRecipeById(int id)
    {
        return _context.Recipes.Find(id);
    }

    // Add new Recipe 
    public void AddRecipe(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        _context.SaveChanges();
    }

    public void DeleteRecipe(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        _context.SaveChanges();
    }


    public void UpdateRecipe(Recipe recipe)
    {
        _context.Recipes.Update(recipe);
        _context.SaveChanges();
    }




}