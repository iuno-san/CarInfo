using Xunit;
using CarInfo.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using FluentAssertions;

namespace CarInfo.Application.ApplicationUser.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
        {
            // arrange
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Email, "iunosan22@gmail.com"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User")
            };

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();

            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user 
            });

            var userContext = new UserContext(httpContextAccessorMock.Object);


            // act
            var currentUser = userContext.GetCurrentUser();


            // assert
            currentUser.Should().NotBeNull();
            currentUser!.Id.Should().Be("1");
            currentUser.Email.Should().Be("iunosan22@gmail.com");
            currentUser.Roles.Should().ContainInOrder("Admin", "User");

        }
    }
}