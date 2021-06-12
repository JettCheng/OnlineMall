using System;
using Core.Dtos;
using AutoMapper;
using Core.Entities;
using Infrastructure.Services.Common;

namespace Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString())
                );
            
            CreateMap<PaginationList<Product>, PaginationList<ProductDto>>();
            CreateMap<ProductForCreationDto, Product>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                )
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => ProductStatus.Using)
                )
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => DateTime.UtcNow)
                );
                // .ForMember(
                //     dest => dest.CreatedBy,
                //     opt => opt.MapFrom(src => DateTime.UtcNow)
                // );

            CreateMap<ProductForUpdateDto, Product>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString())
                )
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.UtcNow)
                );
                // .ForMember(
                //     dest => dest.UpdatedBy,
                //     opt => opt.MapFrom(src => DateTime.UtcNow)
                // );
            CreateMap<Product, ProductForUpdateDto>();
            CreateMap<ProductType, ProductTypeDto>();
        }
    }
}