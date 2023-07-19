using Xunit;
using CarInfo.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarInfo.Application.ApplicationUser.Tests
{
    public class CurrentUserTests
    {
        [Fact()]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue()
        {
            // arrange
            var currentUser = new CurrentUser("1", "iunosan11@gmail.com", new List<string> { "Admin", "User" });
            
            // act
            var isInRole = currentUser.IsInRole("Admin");

            // assert
            isInRole.Should().BeTrue();
        }

        [Fact()]
        public void IsInRole_WithNonMatchingRole_ShouldReturnFalse()
        {
            // arrange
            var currentUser = new CurrentUser("1", "iunosan11@gmail.com", new List<string> { "Admin", "User" });

            // act
            var isInRole = currentUser.IsInRole("Manager");

            // assert
            isInRole.Should().BeFalse();
        }

        [Fact()]
        public void IsInRole_WithNonMatchingCaseRole_ShouldReturnFalse()
        {
            // arrange
            var currentUser = new CurrentUser("1", "iunosan11@gmail.com", new List<string> { "Admin", "User" });

            // act
            var isInRole = currentUser.IsInRole("admin");

            // assert
            isInRole.Should().BeFalse();
        }
    }
}