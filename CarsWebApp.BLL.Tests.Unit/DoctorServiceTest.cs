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
    public class DoctorServiceTest
    {
        [Test]
        public async Task ValidateAsync_DoctorExists_DoesNothing()
        {
            // Arrange
            var doctorContainer = new Mock<IDealerContainer>();

            var doctor = new Dealer();
            var doctorDAL = new Mock<IDealerDAL>();
            var doctorIdentity = new Mock<IDealerIdentity>();
            doctorDAL.Setup(x => x.GetAsync(doctorIdentity.Object)).ReturnsAsync(doctor);

            var doctorGetService = new DealerService(doctorDAL.Object);
            
            // Act
            var action = new Func<Task>(() => doctorGetService.ValidateAsync(doctorContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_DoctorNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var doctorContainer = new Mock<IDealerContainer>();
            doctorContainer.Setup(x => x.DealerId).Returns(id);
            var doctorIdentity = new Mock<IDealerIdentity>();
            var doctor = new Dealer();
            var doctorDAL = new Mock<IDealerDAL>();
            doctorDAL.Setup(x => x.GetAsync(doctorIdentity.Object)).ReturnsAsync((Dealer) null);

            var doctorGetService = new DealerService(doctorDAL.Object);

            // Act
            var action = new Func<Task>(() => doctorGetService.ValidateAsync(doctorContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Dealer not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_DoctorValidationSucceed_CreatesStreet()
        {
            // Arrange
            var doctor = new DealerUpdateModel();
            var expected = new Dealer();

            var doctorDAL = new Mock<IDealerDAL>();
            doctorDAL.Setup(x => x.InsertAsync(doctor)).ReturnsAsync(expected);

            var doctorService = new DealerService(doctorDAL.Object);
            
            // Act
            var result = await doctorService.CreateAsync(doctor);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}