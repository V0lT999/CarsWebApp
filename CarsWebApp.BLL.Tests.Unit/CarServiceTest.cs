using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using CarsWebApp.BLL.Implementation;
using CarsWebApp.DAL.Contracts;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Contracts;
using CarsWebApp.Domain.Models;
using NUnit.Framework;

namespace CarsWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class CarServiceTest
    {
        [Test]
        public async Task ValidateAsync_CarExists_DoesNothing()
        {
            // Arrange
            var carContainer = new Mock<ICarContainer>();

            var car = new Car();
            var carDAL = new Mock<ICarDAL>();
            var carIdentity = new Mock<ICarIdentity>();
            carDAL.Setup(x => x.GetAsync(carIdentity.Object)).ReturnsAsync(car);

            var carGetService = new CarService(carDAL.Object);
            
            // Act
            var action = new Func<Task>(() => carGetService.ValidateAsync(carContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_CarNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var carContainer = new Mock<ICarContainer>();
            carContainer.Setup(x => x.CarId).Returns(id);
            var carIdentity = new Mock<ICarIdentity>();
            var car = new Car();
            var carDAL = new Mock<ICarDAL>();
            carDAL.Setup(x => x.GetAsync(carIdentity.Object)).ReturnsAsync((Car) null);

            var carGetService = new CarService(carDAL.Object);

            // Act
            var action = new Func<Task>(() => carGetService.ValidateAsync(carContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Car not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_CarValidationSucceed_CreatesStreet()
        {
            // Arrange
            var car = new CarUpdateModel();
            var expected = new Car();
            
            var carDAL = new Mock<ICarDAL>();
            carDAL.Setup(x => x.InsertAsync(car)).ReturnsAsync(expected);

            var carService = new CarService(carDAL.Object);
            
            // Act
            var result = await carService.CreateAsync(car);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}