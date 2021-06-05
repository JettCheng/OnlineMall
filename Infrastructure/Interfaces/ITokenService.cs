using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(Customer user);
    }
}