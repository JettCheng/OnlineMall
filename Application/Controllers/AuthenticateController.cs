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

            // Create Token 
            var tokenStr = await _tokenService.CreateToken(user); 

            // return 200 ok + JWT 
            return Ok(new ApiResponseWithData<string>(200,tokenStr));
        }

        [HttpPost]
        public async Task<IActionResult> Register( [FromBody] RegisterDto registerDto )
        {
            // 1 使用用户名创建用户对象
            var user = new Customer()
            {
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            // 2 hash密码，保存用户
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            // 3 return
            return Ok(new ApiResponseWithData<RegisterDto>(200, registerDto, "已成功註冊"));
        }

        [HttpGet]
        [Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetCurrentCustomer()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var customer = await _userManager.FindByEmailFromClaimsPrinciple(user);

            return Ok(new CustomerDto 
            {
                Email = customer.Email,
                Token = await _tokenService.CreateToken(customer),
                Name = customer.UserName
            });
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