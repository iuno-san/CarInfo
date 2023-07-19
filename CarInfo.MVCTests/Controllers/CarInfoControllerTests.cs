// Ignore Spelling: MVC

using Xunit;
using CarInfo.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using CarInfo.Application.CarInfo;
using Moq;
using MediatR;
using CarInfo.Application.CarInfo.Queries.GetAllCarInfo;
using Microsoft.AspNetCore.TestHost;
using FluentAssertions;
using System.Net;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace CarInfo.MVC.Controllers.Tests
{
    public class CarInfoControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CarInfoControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact()]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingCarInfo()
        {
            // arrange
            var CarInfos = new List<CarInfoDto>()
            {
                new CarInfoDto()
                {
                    Name = "CarInfo 1",
                },

                new CarInfoDto()
                {
                    Name = "CarInfo 2",
                },

                new CarInfoDto()
                {
                    Name = "CarInfo 3",
                },
            };

            var mediatorMock = new Mock<IMediator>();

            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCarInfoQueries>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(CarInfos);

            var client = _factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();

            // act
            var response = await client.GetAsync("/CarInfo/Index");


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain("<h1>Car CarInfos</h1>")
                .And.Contain("CarInfo 1")
                .And.Contain("CarInfo 2")
                .And.Contain("CarInfo 3");
        }

        [Fact()]
        public async Task Index_ReturnsEmptyView_WhenNoCarInfoExist()
        {
            // arrange
            var CarInfos = new List<CarInfoDto>();
            

            var mediatorMock = new Mock<IMediator>();

            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCarInfoQueries>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(CarInfos);

            var client = _factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();


            // act
            var response = await client.GetAsync("/CarInfo/Index");


            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().NotContain("div class\"card m-3\"");
        }
    }
}