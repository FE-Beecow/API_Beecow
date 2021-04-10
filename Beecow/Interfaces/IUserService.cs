using Beecow.DTOs.User;
using System.Threading.Tasks;

namespace Beecow.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> Login(LoginUserModel loginRequest);
        Task<RegisterResponse> Register(CreateUserModel registerRequest);
    }
}
