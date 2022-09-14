using AutoMapper;
using RecipeApp.Entities;
using RecipeApp.Models.Users;
using RecipeApp.Models.Specialiste;
using System.Collections.Generic;

namespace WebApi.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<User, UserModel>();
      CreateMap<RegisterModel, User>();
      CreateMap<UserUpdateModel, User>();
    }
  }
}