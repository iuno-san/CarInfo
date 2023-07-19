using AutoMapper;
using CarInfo.Application.ApplicationUser;
using CarInfo.Application.CarInfo;
using CarInfo.Application.CarInfo.Commands.EditCarInfo;
using CarInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfo.Application.Mapping
{
    public class CarInfoMappingProfile : Profile
    {
        public CarInfoMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<CarInfoDto, Domain.Entities.CarInfo>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new CarInfoContactDetails()
                {
                    PhoneNumber = src.PhoneNumber,
                    Address = src.Address,
                    City = src.City,
                }));

            CreateMap<Domain.Entities.CarInfo, CarInfoDto>()
				.ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && (src.CreatedById == user.Id || user.IsInRole("Moderator"))))
				.ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(dto => dto.Address, opt => opt.MapFrom(src => src.ContactDetails.Address))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City));
            
            CreateMap<CarInfoDto, EditCarInfoCommand>();
        }
    }
}
