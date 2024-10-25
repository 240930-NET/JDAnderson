using AutoMapper;
using RecipeManager.Models.DTOs;
using RecipeManager.Models;

namespace RecipeManager.Models;



public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Recipe, RecipeDto>().ReverseMap();
        CreateMap<Ingredient, IngredientDto>().ReverseMap();
    }
}