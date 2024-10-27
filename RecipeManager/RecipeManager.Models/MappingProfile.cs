using AutoMapper;
using RecipeManager.Models.DTOs;
using RecipeManager.Models;

namespace RecipeManager.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ingredient, IngredientDto>().ReverseMap();
        CreateMap<Recipe, RecipeDto>().ReverseMap();
    }
}