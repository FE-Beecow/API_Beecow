using AutoMapper;
using Beecow.DTOs.Account;
using Beecow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beecow.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserModel, User>();
            //.ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => src.first + src.lastname))
            //.ForMember(dest => dest.User_Id, opt => opt.MapFrom(src => 1));

            CreateMap<User, UserViewModel>();
        }
    }
}
