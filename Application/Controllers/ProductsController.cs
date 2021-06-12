using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Application.Parameters;
using Application.ResponseHandlers;
using AutoMapper;
using Core.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Application.Helpers;
using Application.Extensions;
using Infrastructure.Services.Common;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;
        public ProductsController(
            IProductRepository productRepository, 
            IMapper mapper, 
            IUrlHelperFactory urlHelperFactory,
            IActionContextAccessor actionContextAccessor)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }
        
        /// <summary>
        /// 取得商品之商品資訊清單
        /// </summary>
        /// <param name="paginationParameters"></param>
        /// <param name="productParameters"></param>
        /// <returns>商品清單</returns>
        [HttpGet("items",Name = "GetProducts")]
        public async Task<IActionResult> GetProducts( 
            [FromQuery] PaginationParameters paginationParameters,
            [FromQuery] ProductParameters productParameters
        )
        {
            // 取得商品清單
            var productFromRepo = await _productRepository.GetProductsAsync(
                paginationParameters.PageSize,
                paginationParameters.PageNumber,
                paginationParameters.OrderBy, 
                productParameters.Keyword,
                productParameters.ProductTypeId
            );

            if(productFromRepo == null || productFromRepo.Count() <= 0)
            {
                return NotFound( new ApiResponse(404, "查無商品" ) );
            }
            var productListDto = _mapper.Map<IEnumerable<ProductDto>>(productFromRepo);
            

            // 產生分頁資訊
            var paginationMetadata = PaginationInfoExtensions.GeneratePaginationInfo<Product>(
                _urlHelper,
                productFromRepo,
                paginationParameters,
                "GetProducts"
            );
            Response.Headers.Add("x-pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

            return Ok( new ApiResponseWithData<IEnumerable<ProductDto>>(200, productListDto) );
        }

        /// <summary>
        /// 以商品編號取得該商品之商品資訊清單
        /// </summary>
        /// <param name="productId">商品編號</param>
        /// <returns>商品</returns>   
        [HttpGet("{productId}", Name = "GetProductById")]  // https://localhost:5001/api/Products/ef22a3bd-bda1-4ec8-b965-99efbdd8de40
        public async Task<IActionResult> GetProductById( [FromRoute] Guid productId)
        {
            var productFromRepo = await _productRepository.GetProductByIdAsync(productId);
            if (productFromRepo == null)
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productId) );
            }
            var productDto = _mapper.Map<ProductDto>(productFromRepo);
            return Ok( new ApiResponseWithData<ProductDto>(200, productDto) );
        }

        /// <summary>
        /// 搜尋符合關鍵字之商品清單
        /// </summary>
        /// <param name="productParameters"></param>   
        /// <param name="paginationParameters"></param>   
        /// <returns>商品清單</returns>   
        [HttpGet]   // https://localhost:5001/api/Products?Keyword=%E7%AB%A5
        public async Task<IActionResult> GetProductListBySearchingAsync(
            [FromQuery] ProductParameters productParameters, 
            [FromQuery] PaginationParameters paginationParameters
        )
        {
            var productFromRepo = await _productRepository.GetProductListBySearchingAsync(
                productParameters.Keyword,
                paginationParameters.PageSize,
                paginationParameters.PageNumber
            );

            if(productFromRepo == null || productFromRepo.Count() <= 0)
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productParameters.Keyword) );
            }

            var productListDto = _mapper.Map<IEnumerable<ProductDto>>(productFromRepo);

            return Ok( new ApiResponseWithData<IEnumerable<ProductDto>>(200, productListDto) );
        }

        /// <summary>
        /// 新增商品 (可包含商品圖片)
        /// </summary>
        /// <param name="productForCreationDto"></param>   
        /// <returns>商品</returns>   
        [Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]  // https://localhost:5001/api/Products
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto productForCreationDto)
        {
            var productModel = _mapper.Map<Product>(productForCreationDto);
            _productRepository.AddProduct(productModel);
            await _productRepository.SaveAsync();
            var productToReturn = _mapper.Map<ProductDto>(productModel);
            return CreatedAtRoute(
                "GetProductById",
                new { productId = productToReturn.Id },
                new ApiResponseWithData<ProductDto>(200, productToReturn) 
            );
        }

        /// <summary>
        /// 對指定商品編號之商品資訊進行整體內容修改
        /// </summary>
        /// <param name="productId">商品編號</param>   
        /// <param name="productForUpdateDto"></param>   
        /// <returns>無</returns>
        [Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct( [FromRoute] Guid productId, [FromBody] ProductForUpdateDto productForUpdateDto)
        {
            // 確認是否有此Id的商品
            if (!(await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productId) );
            }

            // 取出該商品的資料
            var productFromRepo = await _productRepository.GetProductByIdAsync(productId);

            // 用 AutoMapper 映射新的修改資料到 Entity
            _mapper.Map(productForUpdateDto, productFromRepo);

            // 儲存結果至資料庫
            await _productRepository.SaveAsync();

            return NoContent();
        }

        /// <summary>
        /// 對指定商品編號之商品資訊進行部分內容修改
        /// </summary>
        /// <param name="productId">商品編號</param>   
        /// <param name="patchDocument"></param>   
        /// <returns>無</returns>   
        [Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPatch("{productId}")]
        public async Task<IActionResult> PartiallyUpdateProduct(
            [FromRoute] Guid productId, 
            [FromBody] JsonPatchDocument<ProductForUpdateDto> patchDocument)
        {
            // 確認是否有此Id的商品
            if (!(await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productId) );
            }

            // 取出該商品的資料
            var productFromRepo = await _productRepository.GetProductByIdAsync(productId);

            // 用 AutoMapper 映射新的修改資料到 Entity
            var productToPatch = _mapper.Map<ProductForUpdateDto>(productFromRepo);

            // 根據 patchDocument 的修改指示，以 Dto 呈現
            patchDocument.ApplyTo(productToPatch, ModelState);

            // 檢查修改指示是否 valid
            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }

            // 根據 dto mapping 到 entity
            _mapper.Map(productToPatch, productFromRepo);

            // 儲存結果至資料庫
            await _productRepository.SaveAsync();

            return NoContent();
        }

        /// <summary>
        /// 對特定商品編號之商品進行刪除
        /// </summary>
        /// <param name="productId">商品編號</param>   
        /// <returns>無</returns>   
        [Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProductById( [FromRoute] Guid productId )
        {
            // 確認是否有此Id的商品
            if (!(await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound( new ApiResponse(404, "查無此商品:" + productId) );
            }

            // 取出該商品的資料
            var productFromRepo = await _productRepository.GetProductByIdAsync(productId);

            // 刪除該商品
            _productRepository.DeleteProduct(productFromRepo);

            // 儲存結果至資料庫
            await _productRepository.SaveAsync();

            return NoContent();
        }
    
        /// <summary>
        /// 取得商品主分類
        /// </summary> 
        /// <param name="level">分類層級</param>   
        /// <returns>商品主分類清單</returns>   
        [HttpGet("productTypes/{level}")]
        public async Task<IActionResult> GetProductTypes( [FromRoute] int level)
        {
            var productTypesFromRepo = await _productRepository.GetProductTypesLevel0Async(level);
            
            var productTypesToReturn = _mapper.Map<IEnumerable<ProductTypeDto>>(productTypesFromRepo);

            return Ok( new ApiResponseWithData<IEnumerable<ProductTypeDto>>(200, productTypesToReturn) );
        }

        /// <summary>
        /// 取得商品次分類
        /// </summary> 
        /// <param name="level">分類層級</param>      
        /// <param name="parentId">父分類</param>   
        /// <returns>商品次分類清單</returns>   
        [HttpGet("{parentId}/{level}")]
        public async Task<IActionResult> GetProductTypes( [FromRoute] int level, string parentId)
        {
            var productTypesFromRepo = await _productRepository.GetProductTypesLevel1ByPanentIdAsync(level, parentId);
            
            var productTypesToReturn = _mapper.Map<IEnumerable<ProductTypeDto>>(productTypesFromRepo);

            return Ok( new ApiResponseWithData<IEnumerable<ProductTypeDto>>(200, productTypesToReturn) );
        }
    }
}