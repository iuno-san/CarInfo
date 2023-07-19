using Xunit;
using CarInfo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarInfo.Domain.Entities.Tests
{
    public class CarInfoTests
    {
        [Fact()]
        public void EncodeName_ShouldSetEncodedName()
        {
            //arrange
            var carInfo = new CarInfo();
            carInfo.Name = "Test Car";

            //act
            carInfo.EncodeName();

            //assert
            carInfo.EncodedName.Should().Be("test-car");
        }

        [Fact()]
        public void EncodeName_ShouldThrowException_WhenNameIsNull()
        {
            //arrange
            var carInfo = new CarInfo();

            //act
            Action action = () => carInfo.EncodeName();

            //assert

            action.Invoking(a => a.Invoke())
                .Should().Throw<NullReferenceException>();
        }
    }
}