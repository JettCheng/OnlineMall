using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Application.ResponseHandlers;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/images")]
    public class ProductImagesController : BaseApiController
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductImagesController(IProductImageRepository productImageRepository, IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
        }

        /// <summary>
        /// 以商品編號取得該商品之所有商品圖片
        /// </summary>
        /// <param name="productId">商品編號</param>   
        /// <returns>商品圖片清單</returns>   
        [HttpGet]
        public async Task<IActionResult> GetProductImageListByProductId([FromRoute] Guid productId)
        {
            // 確認是否有此Id的商品
            if (!(await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productId) );
            }

            // 取得該商品的商品圖片清單
            var productImageListFromRepo = await _productImageRepository.GetProductImageListByProductIdAsync(productId);

            // 確認查詢商品圖片
            if (productImageListFromRepo==null || productImageListFromRepo.Count() <= 0)
            {
                return NotFound( new ApiResponse(404, "查無此商品之商品圖片:" + productId) );
            }

            // 將商品圖片清單 Entity 映射到 Dto
            var productImageListDto = _mapper.Map<IEnumerable<ProductImageDto>>(productImageListFromRepo);

            return Ok( new ApiResponseWithData<IEnumerable<ProductImageDto>>(200, productImageListDto) );
        }

        /// <summary>
        /// 以商品圖片編號取得該商品之所有商品圖片
        /// </summary>
        /// <param name="productId">商品編號</param>   
        /// <param name="productImageId">商品圖片編號</param>   
        /// <returns>商品圖片</returns>   
        [HttpGet("{productImageId}")]
        public async Task<IActionResult> GetProductImageByProductImageId( [FromRoute] Guid productId, int productImageId )
        {
            // 確認是否有此Id的商品
            if (!(await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productId) );
            }

            // 取得該商品圖片編號之商品圖片 Entity
            var productImageFromRepo = await _productImageRepository.GetProductImageByProductImageIdAsync(productImageId);

            // 將商品圖片 Entity 映射到 Dto
            var productImageDto = _mapper.Map<ProductImageDto>(productImageFromRepo);

            return Ok( new ApiResponseWithData<ProductImageDto>(200, productImageDto));
        }

        /// <summary>
        /// 新增指定商品之商品圖片
        /// </summary>
        /// <param name="productId">商品編號</param>   
        /// <param name="productImageForCreationDto"></param>   
        /// <returns>商品圖片</returns> 
        [HttpPost]
        public async Task<IActionResult> CreateProductImageForProduct( [FromRoute] Guid productId, [FromBody] ProductImageForCreationDto productImageForCreationDto )
        {
            // 確認是否有此Id的商品
            if (!(await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productId) );
            }

            // 將待新增的商品圖片映射至商品圖片Model
            var productImageModel = _mapper.Map<ProductImage>(productImageForCreationDto);

            // 新增商品圖片
            _productImageRepository.AddProductImageForProductImageAsync(productId, productImageModel);

            // 儲存結果至資料庫
            await _productImageRepository.SaveAsync();

            // 映射回 Dto
            var productImagetoReturn = _mapper.Map<ProductImageDto>(productImageModel);

            return Ok( new ApiResponseWithData<ProductImageDto>(200, productImagetoReturn));
        }

        /// <summary>
        /// 刪除指定商品圖片
        /// </summary>
        /// <param name="productId">商品編號</param>
        /// <param name="productImageId">商品圖片編號</param>   
        /// <returns>商品圖片</returns>
        [HttpDelete("{productImageId}")]
        public async Task<IActionResult> DeleteProductImageByProductImageId( [FromRoute] Guid productId, int productImageId)
        {
            // 確認是否有此Id的商品
            if (!(await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productId) );
            }

            // 取得指定商品圖片編號之商品圖片
            var productImageFromRepo = await _productImageRepository.GetProductImageByProductImageIdAsync(productImageId);

            // 刪除商品圖片
            _productImageRepository.DeleteProductImageByProductImageId(productImageFromRepo);

            // 儲存結果至資料庫
            await _productImageRepository.SaveAsync();

            return NoContent();
        }
    }
}