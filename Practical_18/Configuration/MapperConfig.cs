using AutoMapper;
using Practical_18.Data;
using Practical_18.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_18.Configuration
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserVM>().ReverseMap();
        }
    }
}
