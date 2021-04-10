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
        private readonly BeecowDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(BeecowDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserResponse> Login(LoginUserModel loginRequest)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Email == loginRequest.Username
                                || x.Phone == loginRequest.Username && x.Password == loginRequest.Password);

            if (user == null)
            {
                return null;
            }
            //var passwordHash = HashingHelper.HashUsingPbkdf2(loginRequest.Password, customer.PasswordSalt);

            var token = await Task.Run(() => TokenHelper.GenerateToken(user));

            return new UserResponse
            {
                UserId = user.Id,
                Username = user.Fullname,
                Email = user.Email,
                Phone = user.Phone,
                Token = token,
                BusinessId = user.BusinessId,
            };
        }

        public async Task<RegisterResponse> Register(CreateUserModel model)
        {
            var register = _dbContext.User.FirstOrDefault(customer => (customer.Email == model.Email || customer.Phone == model.Phone));
            if (register != null)
            {
                return null;
            }

            // TODO: add config mapper
            //var user = _mapper.Map<User>(registerRequest);

            var user = new User()
            {
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password,
                Address = model.Address,
                Fullname = model.Fullname,
                Gender = true,
                BusinessId = model.BusinessId
            };

            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return new RegisterResponse { Fullname = user.Fullname, Status = "200", Message = "Success" };

        }

    }
}
