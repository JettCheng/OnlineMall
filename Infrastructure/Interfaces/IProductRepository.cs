using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Services.Common;

namespace Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> ProductExistAsync(Guid productId);
        Task<PaginationList<Product>> GetProductsAsync(int pageSize, int pageNumber, string OrderBy, string keyword, string productTypeId);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductListBySearchingAsync(string keyword, int pageSize, int pageNumber);
        void AddProduct(Product product);
        void DeleteProduct(Product product);

        Task<IEnumerable<ProductType>> GetProductTypesLevel0Async(int level);
        Task<IEnumerable<ProductType>> GetProductTypesLevel1ByPanentIdAsync(int level, string parentId);

        Task<bool> SaveAsync();
    }
}