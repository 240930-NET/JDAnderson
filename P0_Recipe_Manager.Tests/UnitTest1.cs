using Xunit;
using P0_Recipe_Manager;
using System;
using System.Collections.Generic;
using System.IO;

public class RecipeManagerTests
{
    [Fact]
    public void ParseIngredients_ShouldReturnCorrectList()
    {
        // Arrange
        string input = "2 cups of flour, 1 tsp of salt, 3 eggs";

        // Act
        var result = RecipeManager.ParseIngredients(input);

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Contains("2 cups of flour", result);
        Assert.Contains("1 tsp of salt", result);
        Assert.Contains("3 eggs", result);
    }

    [Fact]
    public void AddRecipe_ShouldAddToList()
    {
        // Arrange
        var recipesList = new List<Recipe>();
        var newRecipe = new Recipe 
        { 
            Name = "Chocolate Chip Cookies",
            CookingTime = "15 minutes",
            Servings = 24,
            Ingredients = new List<string> 
            { 
                "2 1/4 cups all-purpose flour",
                "1 tsp baking soda",
                "1 cup butter, softened",
                "3/4 cup granulated sugar",
                "3/4 cup packed brown sugar",
                "1 tsp vanilla extract",
                "2 large eggs",
                "2 cups semi-sweet chocolate chips"
            },
            Instructions = "Preheat oven to 375°F. Mix ingredients. Drop by rounded tablespoons onto baking sheets. Bake for 9 to 11 minutes or until golden brown."
        };

        // Act
        RecipeManager.AddRecipe(recipesList, newRecipe);

        // Assert
        Assert.Single(recipesList);
        Assert.Equal("Chocolate Chip Cookies", recipesList[0].Name);
        Assert.Equal(24, recipesList[0].Servings);
        Assert.Equal(8, recipesList[0].Ingredients.Count);
    }

    [Fact]
    public void AddRecipe_ShouldThrowExceptionForNullList()
    {
        // Arrange
        List<Recipe>? nullList = null;
        var newRecipe = new Recipe { Name = "Test Recipe" };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => RecipeManager.AddRecipe(nullList, newRecipe));
    }

    [Fact]
    public void GetMultlineInput_ShouldReturnCombinedString()
    {
        // Arrange
        var input = new StringReader($"Line 1{Environment.NewLine}Line 2{Environment.NewLine}Line 3{Environment.NewLine}{Environment.NewLine}");
        Console.SetIn(input);

        // Act
        string result = RecipeManager.GetMultlineInput();

        // Assert
        var expected = $"Line 1{Environment.NewLine}Line 2{Environment.NewLine}Line 3";
        Assert.Equal(expected, result.TrimEnd());
    }
}

public class UITests
{
    [Fact]
    public void GetChoice_ShouldReturnCorrectValue()
    {
        // Arrange
        var input = new StringReader("2");
        Console.SetIn(input);

        // Act
        int result = UI.GetChoice();

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void GetChoice_ShouldReturnZeroForInvalidInput()
    {
        // Arrange
        var input = new StringReader("invalid");
        Console.SetIn(input);

        // Act
        int result = UI.GetChoice();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void DisplayRecipe_ShouldNotThrowException()
    {
        // Arrange
        var recipe = new Recipe
        {
            Name = "Spaghetti Carbonara",
            CookingTime = "20 minutes",
            Servings = 4,
            Ingredients = new List<string> 
            { 
                "400g spaghetti", 
                "200g pancetta", 
                "4 large eggs", 
                "100g Parmesan cheese", 
                "Freshly ground black pepper" 
            },
            Instructions = "1. Cook pasta. 2. Fry pancetta. 3. Beat eggs with cheese. 4. Combine all ingredients."
        };

        // Act & Assert
        var exception = Record.Exception(() => UI.DisplayRecipe(recipe));
        Assert.Null(exception);
    }

    [Fact]
    public void DisplayAllRecipes_ShouldHandleEmptyList()
    {
        // Arrange
        var emptyList = new List<Recipe>();

        // Act & Assert
        var exception = Record.Exception(() => UI.DisplayAllRecipes(emptyList));
        Assert.Null(exception);
    }
}