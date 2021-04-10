using Beecow.DTOs.User;
using System.Threading.Tasks;

namespace Beecow.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> Login(LoginUserModel loginRequest);
        Task<RegisterViewModel> Register(CreateUserModel registerRequest);
    }
}
