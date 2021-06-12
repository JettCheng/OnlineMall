using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Dtos;
using Application.Extensions;
using Application.ResponseHandlers;
using Core.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Application.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticateController : BaseApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _config;
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly ITokenService _tokenService;
        public AuthenticateController(
            IHttpContextAccessor httpContextAccessor,
            IConfiguration config,
            UserManager<Customer> userManager,
            SignInManager<Customer> signInManager,
            ITokenService tokenService
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        /// <summary>
        /// 用戶登入
        /// </summary>
        /// <param name="loginDto"></param>   
        /// <returns>令牌</returns>   
        [AllowAnonymous] // 允許匿名訪問 using Authorization
        [HttpPost("login")]
            public async Task<IActionResult> Login( [FromBody] LoginDto loginDto )
        {
            // 確認有無用戶帳號
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            // 驗證用戶密碼
            var loginResult = await _signInManager.PasswordSignInAsync(
                user.UserName,
                loginDto.Password,
                false,
                false
            );
            if(!loginResult.Succeeded) return Unauthorized(new ApiResponse(401));

            // Create CustomerDto included token
            var CustomerDtoToReturn = new CustomerDto 
            {
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                Name = user.UserName
            };
            // return 200 ok + JWT 
            return Ok(new ApiResponseWithData<CustomerDto>(200, CustomerDtoToReturn));
        }

        /// <summary>
        /// 用戶註冊
        /// </summary>
        /// <param name="registerDto"></param>   
        /// <returns>註冊資訊</returns>   
        [HttpPost]
        public async Task<IActionResult> Register( [FromBody] RegisterDto registerDto )
        {
            // 1 使用用戶名創建用戶對象
            var user = new Customer()
            {
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            // 2 hash密碼，保存用戶
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            // 3 return
            return Ok(new ApiResponseWithData<RegisterDto>(200, registerDto, "已成功註冊"));
        }

        /// <summary>
        /// 取得當前用戶資訊
        /// </summary>  
        /// <returns>當前用戶資訊與新令牌</returns>  
        [HttpGet]
        [Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetCurrentCustomer()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var customer = await _userManager.FindByEmailFromClaimsPrinciple(user);
            var CustomerDtoToReturn = new CustomerDto 
            {
                Email = customer.Email,
                Token = await _tokenService.CreateToken(customer),
                Name = customer.UserName
            };
            return Ok( new ApiResponseWithData<CustomerDto>(200, CustomerDtoToReturn));
        }

        [HttpGet]
        [Route("claims")]
        [Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetCustomerClaims()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var value = user.FindFirstValue("myClaim");
            return Ok(value);
        }
    }
}