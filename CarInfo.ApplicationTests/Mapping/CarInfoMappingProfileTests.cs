// Ignore Spelling: Dto

using Xunit;
using CarInfo.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInfo.Application.ApplicationUser;
using Moq;
using AutoMapper;
using CarInfo.Application.CarInfo;
using FluentAssertions;
using CarInfo.Domain.Entities;

namespace CarInfo.Application.Mapping.Tests
{
    public class CarInfoMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapCarInfoDtoToCarInfo()
        {
            //arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "iunosan27@gmail.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(
                cfg => cfg.AddProfile(new CarInfoMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var dto = new CarInfoDto
            {
                City = "Busko",
                PhoneNumber = "123456789",
                Address = "Widuchowa"
            };

            //act

            var result = mapper.Map<Domain.Entities.CarInfo>(dto);


            //assert

            result.Should().NotBeNull();
            result.ContactDetails.Should().NotBeNull();
            result.ContactDetails.City.Should().Be(dto.City);
            result.ContactDetails.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.ContactDetails.Address.Should().Be(dto.Address);
        }

        [Fact()]
        public void MappingProfile_ShouldMapCarInfoToCarInfoDto()
        {
            //arrange
            var userContextMock = new Mock<IUserContext>();
            userContextMock
                .Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "iunosan27@gmail.com", new[] { "Moderator" }));

            var configuration = new MapperConfiguration(
                cfg => cfg.AddProfile(new CarInfoMappingProfile(userContextMock.Object)));

            var mapper = configuration.CreateMapper();

            var carInfo = new Domain.Entities.CarInfo
            {
                Id = 1,
                CreatedById = "1",
                ContactDetails = new CarInfoContactDetails
                {
                    City = "Busko",
                    PhoneNumber = "123456789",
                    Address = "Widuchowa"
                }
            };

            //act

            var result = mapper.Map<CarInfoDto>(carInfo);


            //assert

            result.Should().NotBeNull();

            result.IsEditable.Should().BeTrue();

            result.City.Should().Be(carInfo.ContactDetails.City);
            result.PhoneNumber.Should().Be(carInfo.ContactDetails.PhoneNumber);
            result.Address.Should().Be(carInfo.ContactDetails.Address);
        }
    }
}