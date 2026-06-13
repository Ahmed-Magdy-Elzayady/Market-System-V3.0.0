using AutoMapper;
using MarketSystem.BLL.DTOs.Account;
using MarketSystem.BLL.DTOs.Produtc;
using MarketSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSystem.BLL.AutoMapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, ProductReadAllDTO>().ReverseMap();
            CreateMap<ProductModel, ProductAddDTO>().ReverseMap();
            CreateMap<ProductModel, ProductUpdateDTO>().ReverseMap();
            CreateMap<ProductModel, ProductGetByIDDTO>().ReverseMap();
            CreateMap<ProductModel, ProducGetByTitleDTO>().ReverseMap();

            CreateMap<CategoryModel, CategoryReadAllDTO>().ReverseMap();
            CreateMap<CategoryModel, CategoryAddDto>().ReverseMap();
            CreateMap<CategoryModel, CategoryGetByIDDTO>().ReverseMap();
            CreateMap<CategoryModel, CategoryUpdateDTO>().ReverseMap();
            CreateMap<CategoryModel, CategoryGetByTitleDTO>().ReverseMap();

            CreateMap<ApplicationUser, RegisterDTO>().ReverseMap();
        }
    }
}
