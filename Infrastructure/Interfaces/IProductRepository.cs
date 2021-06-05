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
        Task<PaginationList<Product>> GetProductListAsync(int pageSize, int pageNumber, string OrderBy);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductListBySearchingAsync(string keyword, int pageSize, int pageNumber);
        void AddProduct(Product product);
        void DeleteProduct(Product product);


        Task<bool> SaveAsync();
    }
}