using AutoMapper;
using BMS_API.Models.Domains;
using BMS_API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMS_API.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDetail, UserDetailDTO>().ReverseMap();
            CreateMap<LoanDetail, LoanDetailDTO>().ReverseMap();
        }
    }
}
