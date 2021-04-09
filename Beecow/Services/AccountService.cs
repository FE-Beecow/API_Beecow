using AutoMapper;
using Beecow.DTOs.Account;
using Beecow.Entities;
using Beecow.Helpers;
using Beecow.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Services
{

    public class AccountService : IAccountService
    {
        private readonly CustomersDbContext customersDbContext;
        private readonly IMapper _mapper;
        public AccountService(CustomersDbContext customersDbContext, IMapper mapper )
        {
            this.customersDbContext = customersDbContext;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Login(LoginUserModel loginRequest)
        {
            var customer = customersDbContext.Customers.SingleOrDefault(customer => (customer.Email == loginRequest.Username || customer.Phone == loginRequest.Username));

            if (customer == null)
            {
                return null;
            }

            if (customer.Password != loginRequest.Password)
            {
                return null;
            }

            var token = await Task.Run(() => TokenHelper.GenerateToken(customer));

            return new UserViewModel { Username = customer.Fullname, Email = customer.Email, Phone = customer.Phone, Token = token };
        }

        public async Task<RegisterViewModel> Register(CreateUserModel registerRequest)
        {
            var register = customersDbContext.Customers.SingleOrDefault(customer => (customer.Email == registerRequest.Email || customer.Phone == registerRequest.Phone));
            if (register != null)
            {
                return null;
            }

            var customer = _mapper.Map<User>(registerRequest);

            await customersDbContext.Customers.AddAsync(customer);
            await customersDbContext.SaveChangesAsync();

            return new RegisterViewModel { Fullname = customer.Fullname, Status = "200", Message = "Success" };

        }
    }
}
