using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using CarsWebApp.BLL.Contracts;
using CarsWebApp.BLL.Implementation;
using CarsWebApp.DAL.Contracts;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;
using NUnit.Framework;

namespace CarsWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class CityServiceTest
    {
        [Test]
        public async Task ValidateAsync_CityExists_DoesNothing()
        {
            // Arrange
            var cityContainer = new Mock<ICityContainer>();

            var city = new City();
            var cityDAL = new Mock<ICityDAL>();
            var cityIdentity = new Mock<ICityIdentity>();
            cityDAL.Setup(x => x.GetAsync(cityIdentity.Object)).ReturnsAsync(city);

            var cityGetService = new CityService(cityDAL.Object);
            
            // Act
            var action = new Func<Task>(() => cityGetService.ValidateAsync(cityContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_CityNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var cityContainer = new Mock<ICityContainer>();
            cityContainer.Setup(x => x.CityId).Returns(id);
            var cityIdentity = new Mock<ICityIdentity>();
            var city = new City();
            var cityDAL = new Mock<ICityDAL>();
            cityDAL.Setup(x => x.GetAsync(cityIdentity.Object)).ReturnsAsync((City) null);

            var cityGetService = new CityService(cityDAL.Object);

            // Act
            var action = new Func<Task>(() => cityGetService.ValidateAsync(cityContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"City not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_CityValidationSucceed_CreatesCity()
        {
            // Arrange
            var city = new CityUpdateModel();
            var expected = new City();
            
            var cityDAL = new Mock<ICityDAL>();
            cityDAL.Setup(x => x.InsertAsync(city)).ReturnsAsync(expected);

            var cityService = new CityService(cityDAL.Object);
            
            // Act
            var result = await cityService.CreateAsync(city);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}