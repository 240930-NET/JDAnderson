using Moq;
using Xunit;
using RecipeManager.API.Services;
using RecipeManager.Data;
using RecipeManager.Models;
using RecipeManager.Models.DTOs;
using System;
using AutoMapper; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeManager.Tests
{
    public class RecipeServiceTests
    {
        private readonly Mock<IRecipeRepo> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly RecipeService _recipeService;

        public RecipeServiceTests()
        {
            _mockRepo = new Mock<IRecipeRepo>();
            _mockMapper = new Mock<IMapper>();
            _recipeService = new RecipeService(_mockRepo.Object, null, null, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAllRecipesThrowsExceptionOnEmpty()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAllRecipes()).ReturnsAsync(new List<Recipe>());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _recipeService.GetAllRecipes());
        }

        [Fact]
        public async Task GetAllRecipesReturnsProperList()
        {
            // Arrange
            List<Recipe> recipeList = new List<Recipe>
            {
                new Recipe { Name = "Pasta", Instructions = "Cook pasta", CookingTime = "30 minutes" },
                new Recipe { Name = "Salad", Instructions = "Mix vegetables", CookingTime = "15 minutes" },
                new Recipe { Name = "Soup", Instructions = "Boil ingredients", CookingTime = "45 minutes" }
            };

            _mockRepo.Setup(repo => repo.GetAllRecipes()).ReturnsAsync(recipeList);

            // Act
            var result = await _recipeService.GetAllRecipes();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Contains(result, r => r.Name.Equals("Pasta"));
        }

        [Fact]
        public async Task GetRecipeByIdReturnsRecipe()
        {
            // Arrange
            var recipe = new Recipe { RecipeId = 1, Name = "Pasta", Instructions = "Cook pasta", CookingTime = "30 minutes" };
            _mockRepo.Setup(repo => repo.GetRecipeById(1)).ReturnsAsync(recipe);

            // Act
            var result = await _recipeService.GetRecipeById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Pasta", result.Name);
        }

        [Fact]
        public async Task GetRecipeByIdReturnsNullWhenNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetRecipeById(1)).ReturnsAsync((Recipe)null);

            // Act
            var result = await _recipeService.GetRecipeById(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task AddRecipeThrowsExceptionWhenNameIsEmpty()
        {
            // Arrange
            var recipeDto = new RecipeDto { Name = "", Instructions = "Test", CookingTime = "30 min" };
            _mockMapper.Setup(m => m.Map<Recipe>(It.IsAny<RecipeDto>()))
                       .Returns(new Recipe { Name = recipeDto.Name, Instructions = recipeDto.Instructions, CookingTime = recipeDto.CookingTime });

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _recipeService.AddRecipe(recipeDto));
        }
    }

}