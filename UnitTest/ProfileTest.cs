using AutoMapper;
using BackEnd.Profiles;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTest
{
    public class ProfileTest
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AllProfile>());
            IMapper mapper = config.CreateMapper();

            // Act
            Action act = () => mapper.ConfigurationProvider.AssertConfigurationIsValid();

            // Assert
            act.Should().NotThrow();
        }
    }
}