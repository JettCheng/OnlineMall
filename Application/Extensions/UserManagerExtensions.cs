using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<Customer> FindByEmailFromClaimsPrinciple( this UserManager<Customer> input, ClaimsPrincipal customer )
        {
            var email = customer.FindFirstValue(ClaimTypes.Email);
            return await input.Users.SingleOrDefaultAsync( x => x.Email == email );
        }
        
    }
}