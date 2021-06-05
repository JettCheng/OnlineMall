using System;
using Core.Dtos;
using AutoMapper;
using Core.Entities;

namespace Application.Profiles
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImageForCreationDto, ProductImage>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => ProductImageStatus.Using)
                )       
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => DateTime.UtcNow)
                );
        }
    }
}