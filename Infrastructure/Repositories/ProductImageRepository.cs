using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Database.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        public AppDbContext _context;
        public ProductImageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductImage>> GetProductImageListByProductIdAsync(Guid productId)
        {
            return await _context.ProductImages
                .Where(pi => pi.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductImage> GetProductImageByProductImageIdAsync(int productImageId)
        {
            return await _context.ProductImages
                .Where(pi => pi.Id == productImageId)
                .FirstOrDefaultAsync();
        }

        public void AddProductImageForProductImageAsync(Guid productId, ProductImage productImage)
        {
            if (productImage == null)
            {
                throw new ArgumentNullException(nameof(productImage));
            }
            productImage.ProductId = productId;
            _context.ProductImages.Add(productImage);
        }

        public void DeleteProductImageByProductImageId(ProductImage productImage)
        {
            if (productImage == null)
            {
                throw new ArgumentNullException(nameof(productImage));
            }
            _context.ProductImages.Remove(productImage);
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}