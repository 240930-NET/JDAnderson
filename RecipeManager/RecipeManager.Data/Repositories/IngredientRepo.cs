namespace RecipeManager.Data; 
using RecipeManager.Models; 
using Microsoft.EntityFrameworkCore;  

public class IngredientRepo : IIngredientRepo { 
	private readonly RecipeContext _context; 

	public IngredientRepo(RecipeContext context) { 
		_context = context; 
	}

	public async Task<List<Ingredient>> GetAllIngredients() { 
		return await _context.Ingredients.ToListAsync(); 
	}

	public async Task<Ingredient>? GetIngredientById(int id){ 
		return await _context.Ingredients.Include(I => I.Recipe).FirstOrDefaultAsync(I => I.RecipeId == id)?? throw new InvalidOperationException($"Ingredient with ID {id} not found.");; 
	}

	 public async Task<Ingredient> AddIngredient(Ingredient ingredient){
		await _context.Ingredients.AddAsync(ingredient);
		await _context.SaveChangesAsync();
		return ingredient;
	}
	public async Task<Ingredient> UpdateIngredient(Ingredient ingredient){
		_context.Ingredients.Update(ingredient);
		await _context.SaveChangesAsync();
		return ingredient;
	}
	public async Task DeleteIngredient(Ingredient ingredient){
		_context.Ingredients.Remove(ingredient);
		await _context.SaveChangesAsync();
	}
	
	 public async Task<List<Ingredient>> AddMultipleIngredients(List<Ingredient> ingredients)
    {
        await _context.Ingredients.AddRangeAsync(ingredients);
        await _context.SaveChangesAsync();
        return ingredients;
    }
}