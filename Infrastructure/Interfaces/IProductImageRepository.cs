using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Interfaces
{
    public interface IProductImageRepository
    {
        Task<IEnumerable<ProductImage>> GetProductImageListByProductIdAsync(Guid productId);
        Task<ProductImage> GetProductImageByProductImageIdAsync(int productImageId);
        void AddProductImageForProductImageAsync(Guid productId, ProductImage productImage);
        void DeleteProductImageByProductImageId(ProductImage productImage);
        
        Task<bool> SaveAsync();

    }
}