using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<Customer> _userManager;
        public TokenService(IConfiguration config, UserManager<Customer> userManager)
        {
            _userManager = userManager;
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:SecretKey"]));

        }

        public async Task<string> CreateToken(Customer customer)
        {
            // 2.創建JWT
            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            var claims = new List<Claim>();
            claims.Add( new Claim(JwtRegisteredClaimNames.Email, customer.Email) );
            claims.Add( new Claim("myClaim", "myClaim") );

            var roleNames = await _userManager.GetRolesAsync(customer);
            foreach(var roleName in roleNames)
            {
                var roleClaim = new Claim(ClaimTypes.Role, roleName);
                claims.Add(roleClaim);
            }

            var secretByte = Encoding.UTF8.GetBytes(_config["Authentication:SecretKey"]);
            var signingKey = new SymmetricSecurityKey(secretByte);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgorithm);
            var token = new JwtSecurityToken(
                issuer: _config["Authentication:Issuer"],        // 誰發布這個token
                audience: _config["Authentication:Audience"],    // 發布給誰 哪個前端
                claims,
                notBefore: DateTime.UtcNow,                      // 發布時間
                expires: DateTime.UtcNow.AddDays(1),             // 有效期 ex: +1day
                signingCredentials
            );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenStr;
        }
    }
}