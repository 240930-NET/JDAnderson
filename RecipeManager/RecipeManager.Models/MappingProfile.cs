using AutoMapper;
using RecipeManager.Models.DTOs;


namespace RecipeManager.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ingredient, IngredientDto>().ReverseMap();
        CreateMap<Recipe, RecipeDto>().ReverseMap();
        CreateMap<RecipeUpdateDto, Recipe>(); 
        CreateMap<IngredientDto,Ingredient>().ReverseMap(); 
    }
}