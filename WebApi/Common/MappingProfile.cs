using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.CategoryOperations.Commands.CreateCategory;
using WebApi.Application.CategoryOperations.Commands.UpdateCategory;
using WebApi.Application.CategoryOperations.Queries.GetCategories;
using WebApi.Application.CategoryOperations.Queries.GetCategoryDetail;
using WebApi.Application.MeasureOperations.Commands.CreateMeasure;
using WebApi.Application.MeasureOperations.Commands.UpdateMeasure;
using WebApi.Application.MeasureOperations.Queries.GetMeasureDetail;
using WebApi.Application.MeasureOperations.Queries.GetMeasures;
using WebApi.Application.ProductOperations.Commands.CreateProduct;
using WebApi.Application.ProductOperations.Commands.UpdateProduct;
using WebApi.Application.ProductOperations.Queries.GetProductDetail;
using WebApi.Application.ProductOperations.Queries.GetProducts;
using WebApi.Application.ProductShoppingListOperations.Commands.CreateProductShoppingList;
using WebApi.Application.ProductShoppingListOperations.Commands.UpdateProductShoppingList;
using WebApi.Application.ProductShoppingListOperations.Queries.GetProductShoppingListDetail;
using WebApi.Application.ProductShoppingListOperations.Queries.GetProductShoppingLists;
using WebApi.Application.ShoppingListOperations.Commands.CreateShoppingList;
using WebApi.Application.ShoppingListOperations.Commands.UpdateShoppingList;
using WebApi.Application.ShoppingListOperations.Queries.GetShoppingListDetail;
using WebApi.Application.ShoppingListOperations.Queries.GetShoppingLists;
using WebApi.Application.UserOperations.Commands.CreateUser;
using WebApi.Application.UserOperations.Commands.UpdateUser;
using WebApi.Application.UserOperations.Queries.GetUserDetail;
using WebApi.Application.UserOperations.Queries.GetUsers;
using WebApi.Entities;


namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoriesViewModel>();
            CreateMap<Category,CategoryDetailViewModel>();
            CreateMap<CreateCategoryModel, Category>();
            CreateMap<UpdateCategoryModel, Category>();

            CreateMap<Measure, MeasuresViewModel>();
            CreateMap<Measure,MeasureDetailViewModel>();
            CreateMap<CreateMeasureModel, Measure>();
            CreateMap<UpdateMeasureModel, Measure>();
            
            CreateMap<CreateProductModel,Product>();
            CreateMap<Product,ProductDetailViewModel>().ForMember(dest => dest.Category, opt=>opt.MapFrom(src=>src.Category.Title)).ForMember(dest => dest.Measure, opt=>opt.MapFrom(src=>src.Measure.Title));
            CreateMap<Product,ProductsViewModel>().ForMember(dest => dest.Category, opt=>opt.MapFrom(src=>src.Category.Title)).ForMember(dest => dest.Measure, opt=>opt.MapFrom(src=>src.Measure.Title));

            CreateMap<CreateProductShoppingListModel,ProductShoppingList>();
            CreateMap<ProductShoppingList,ProductShoppingListDetailViewModel>();
            CreateMap<ProductShoppingList,ProductShoppingListsViewModel>();
            CreateMap<UpdateProductShoppingListModel, ProductShoppingList>();

            CreateMap<CreateUserModel , User>();
            CreateMap<User, UsersViewModel>();
            CreateMap<User, UserDetailViewModel>();
            CreateMap<UpdateUserModel, User>();

            CreateMap<CreateShoppingListModel , ShoppingList>();
            CreateMap<UpdateShoppingListModel, ShoppingList>();
            CreateMap<ShoppingList, ShoppingListQueryViewModel>().ForMember(dest => dest.User, opt=>opt.MapFrom(src=>src.User.Name+ " "+ src.User.Surname)).ForMember(dest => dest.ProductShoppingLists, opt => opt.MapFrom(m => m.ProductShoppingLists.Select(s => s.Product.Title)));
            CreateMap<ShoppingList, ShoppingListDetailViewModel>().ForMember(dest => dest.User, opt=>opt.MapFrom(src=>src.User.Name+ " "+ src.User.Surname)).ForMember(dest => dest.ProductShoppingLists, opt => opt.MapFrom(m => m.ProductShoppingLists.Select(s => s.Product.Title)));


        }
    }
}