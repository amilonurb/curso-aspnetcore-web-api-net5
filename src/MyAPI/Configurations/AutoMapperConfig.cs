using AutoMapper;
using MyAPI.Business.Models;
using MyAPI.ViewModels;

namespace MyAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProdutoViewModel, Produto>().ReverseMap();
        }
    }
}