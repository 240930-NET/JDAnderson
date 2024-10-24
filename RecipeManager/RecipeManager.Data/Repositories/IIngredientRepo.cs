namespace RecipeManager.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeManager.Models;
public interface IIngredientRepo
{

    Task<List<Ingredient>>? GetAllIngredients();

    Task<Ingredient>? GetIngredientById(int id);

    public Task<Ingredient> AddIngredient(Ingredient ingredient);
    public Task<Ingredient> UpdateIngredient(Ingredient ingredient);
    public Task DeleteIngredientById(Ingredient ingredient); // return void

}