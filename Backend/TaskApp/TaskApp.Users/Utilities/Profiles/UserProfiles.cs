using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskApp.Users.Data.Commands;
using TaskApp.Users.Data.Dtos;
using TaskApp.Users.Data.Events;
using TaskApp.Users.Data.Models;

namespace TaskApp.Users.Utilities.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<CreateUser, User>();
            CreateMap<User, UserReadDto>();
            CreateMap<CreateUser, UserCreated>();
            CreateMap<UserCreated, UserReadDto>();
        }
    }
}
