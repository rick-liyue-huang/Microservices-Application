﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.eCommerce.Core.DTOs;
using UserService.eCommerce.Core.Entities;

namespace UserService.eCommerce.Core.Mappers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile() 
        {
            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID));

            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(sr => sr.PersonName));

            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.Success, opt => opt.Ignore());

            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());

        }
    }
}
