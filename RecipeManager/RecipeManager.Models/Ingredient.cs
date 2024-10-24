using RecipeManager.Models;
using System.ComponentModel.DataAnnotations;

public class Ingredient { 
    public int IngredientId {get; set;}
    
    public string Name { get; set; } = "";

    public string Quantity { get; set; } = ""; 
    public int RecipeId {get; set;}

    [Required]
    public Recipe? Recipes {get; set;}
}