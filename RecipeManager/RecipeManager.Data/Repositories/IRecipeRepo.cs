using RecipeManager.Models; 
public interface IRecipeRepo { 
    public List<Recipe> GetAllRecipes(); 

    public Recipe? GetRecipeById(int id); 

}