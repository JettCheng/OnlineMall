using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Database.Domain;
using Infrastructure.Services.Common;
using Infrastructure.Services.PropertyMapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IPropertyMappingService _propertyMappingService;
        public ProductRepository(AppDbContext context, IPropertyMappingService propertyMappingService)
        {
            _propertyMappingService = propertyMappingService;
            _context = context;
        }

        public async Task<bool> ProductExistAsync(Guid productId)
        {
            return await _context.Products.AnyAsync(p => p.Id == productId);
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await _context.Products.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<PaginationList<Product>> GetProductsAsync(
            int pageSize,
            int pageNumber,
            string orderBy,
            string keyword,
            string productTypeId
        )
        {
            IQueryable<Product> result = _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductImages);

            if(!string.IsNullOrEmpty(keyword))
            {
                result = result.Where(p => p.Title.Contains(keyword));
            }
            
            if(!string.IsNullOrEmpty(productTypeId))
            {
                result= result.Where(p => p.ProductTypeId.Contains(productTypeId));
            }

            if (!(string.IsNullOrEmpty(orderBy)))
            {
                // 把兩個需要 mapping 的 class 丟進去，回傳的就是 mapping 成功的屬性對照列表
                var productMappingDictionary = _propertyMappingService.GetPropertyMapping<ProductDto, Product>();

                // 根據屬性對照列表結果將資料進行重新排序
                result = result.ApplySort(orderBy, productMappingDictionary);
            }
            
            return await PaginationList<Product>.CreateAsync(pageNumber, pageSize, result);
        }

        public async Task<IEnumerable<Product>> GetProductListBySearchingAsync(
                string keyword,
                int pageSize,
                int pageNumber
            )
        {
            IQueryable<Product> result = _context.Products.Include(p => p.ProductImages);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(x => x.Title.Contains(keyword));
            }
            return await PaginationList<Product>.CreateAsync(pageNumber, pageSize, result);
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Add(product);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesLevel0Async(int level)
        {
            return await _context.ProductTypes.Where(pt => pt.Level==level).ToListAsync();
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesLevel1ByPanentIdAsync(int level, string parentId)
        {
            return await _context.ProductTypes.Where(pt => pt.Level==level&&pt.ParentId==parentId).ToListAsync();
        }
    }
}