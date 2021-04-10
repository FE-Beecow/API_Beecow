using AutoMapper;
using Beecow.DTOs.User;
using Beecow.Entities;
using Beecow.Helpers;
using Beecow.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Services
{
    public class UserService : IUserService
    {
        private readonly BeecowDbContext customersDbContext;
        private readonly IMapper _mapper;
        public UserService(BeecowDbContext customersDbContext, IMapper mapper)
        {
            this.customersDbContext = customersDbContext;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Login(LoginUserModel loginRequest)
        {
            var user = customersDbContext.User.FirstOrDefault(x => x.Email == loginRequest.Username
                                || x.Phone == loginRequest.Username && x.Password == loginRequest.Password);

            if (user == null)
            {
                return null;
            }
            //var passwordHash = HashingHelper.HashUsingPbkdf2(loginRequest.Password, customer.PasswordSalt);

            var token = await Task.Run(() => TokenHelper.GenerateToken(user));

            return new UserViewModel
            {
                UserId = user.Id,
                Username = user.Fullname,
                Email = user.Email,
                Phone = user.Phone,
                Token = token,
                BusinessId = user.BusinessId,
            };
        }

        public async Task<RegisterViewModel> Register(CreateUserModel registerRequest)
        {
            var register = customersDbContext.User.SingleOrDefault(customer => (customer.Email == registerRequest.Email || customer.Phone == registerRequest.Phone));
            if (register != null)
            {
                return null;
            }

            var customer = _mapper.Map<User>(registerRequest);

            await customersDbContext.User.AddAsync(customer);
            await customersDbContext.SaveChangesAsync();

            return new RegisterViewModel { Fullname = customer.Fullname, Status = "200", Message = "Success" };

        }

    }
}
