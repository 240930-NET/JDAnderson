using RecipeManager.Models;
using RecipeManager.Data; 
using RecipeManager.Models.DTOs; 

namespace RecipeManager.API.Services;

public interface IIngredientService
{
    Task<Ingredient?> GetIngredientById(int id);
    Task<List<Ingredient>> GetIngredients();

    public Task<Ingredient> AddUser(NewUserDTO user);
    public Task<User> UpdateUser(Ingredient user);
    public Task DeleteUser(int id);
}