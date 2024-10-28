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
    public class IngredientServiceTests
    {
        private readonly Mock<IIngredientRepo> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IngredientService _ingredientService;

        public IngredientServiceTests()
        {
            _mockRepo = new Mock<IIngredientRepo>();
            _mockMapper = new Mock<IMapper>();
            _ingredientService = new IngredientService(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetIngredientByIdReturnsIngredient()
        {
            // Arrange
            var ingredient = new Ingredient { IngredientId = 1, Name = "Salt", Quantity = "1 tsp" };
            _mockRepo.Setup(repo => repo.GetIngredientById(1)).ReturnsAsync(ingredient);

            // Act
            var result = await _ingredientService.GetIngredientById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Salt", result.Name);
        }

        [Fact]
        public async Task GetIngredientByIdThrowsExceptionWhenNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetIngredientById(1)).ReturnsAsync((Ingredient)null);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _ingredientService.GetIngredientById(1));
        }

        [Fact]
        public async Task GetAllIngredientsReturnsProperList()
        {
            // Arrange
            List<Ingredient> ingredientList = new List<Ingredient>
            {
                new Ingredient { Name = "Salt", Quantity = "1 tsp" },
                new Ingredient { Name = "Pepper", Quantity = "1/2 tsp" }
            };

            _mockRepo.Setup(repo => repo.GetAllIngredients()).ReturnsAsync(ingredientList);

            // Act
            var result = await _ingredientService.GetAllIngredients();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, i => i.Name.Equals("Salt"));
        }

        [Fact]
        public async Task GetAllIngredientsThrowsExceptionWhenEmpty()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAllIngredients()).ReturnsAsync(new List<Ingredient>());

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _ingredientService.GetAllIngredients());
        }

        [Fact]
        public async Task AddIngredientThrowsExceptionWhenNameIsEmpty()
        {
            // Arrange
            var ingredientDto = new IngredientDto { Name = "", Quantity = "1 tsp" };
            _mockMapper.Setup(m => m.Map<Ingredient>(It.IsAny<IngredientDto>()))
                       .Returns(new Ingredient { Name = ingredientDto.Name, Quantity = ingredientDto.Quantity });

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _ingredientService.AddIngredient(ingredientDto));
        }
    }
}