using System;
using System.Collections.Generic;
using Core.Entities;

namespace Core.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }
        
        public double OriginalPrice { get; set; }

        public ProductTypeDto ProductType { get; set; }
        
        public ProductStatus Status { get; set; }

        public string CoverImageUrl { get; set;}   // 商品封面
        
        public ICollection<ProductImageDto> ProductImages { get; set; }
        
    }
}