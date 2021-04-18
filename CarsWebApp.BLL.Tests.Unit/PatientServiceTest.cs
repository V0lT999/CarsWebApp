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
    public class PatientServiceTest
    {
        [Test]
        public async Task ValidateAsync_PatientExists_DoesNothing()
        {
            // Arrange
            var patientContainer = new Mock<IBuyerContainer>();

            var patient = new Buyer();
            var streetService = new Mock<ICityService>();
            var patientDAL = new Mock<IBuyerDAL>();
            var patientIdentity = new Mock<IBuyerIdentity>();
            patientDAL.Setup(x => x.GetAsync(patientIdentity.Object)).ReturnsAsync(patient);

            var patientGetService = new BuyerService(patientDAL.Object,streetService.Object);
            
            // Act
            var action = new Func<Task>(() => patientGetService.ValidateAsync(patientContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_PatientNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var patientContainer = new Mock<IBuyerContainer>();
            patientContainer.Setup(x => x.BuyerId).Returns(id);
            var patientIdentity = new Mock<IBuyerIdentity>();
            var streetService = new Mock<ICityService>();
            var patient = new Buyer();
            var patientDAL = new Mock<IBuyerDAL>();
            patientDAL.Setup(x => x.GetAsync(patientIdentity.Object)).ReturnsAsync((Buyer) null);

            var patientGetService = new BuyerService(patientDAL.Object,streetService.Object);

            // Act
            var action = new Func<Task>(() => patientGetService.ValidateAsync(patientContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Buyer not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_PatientValidationSucceed_CreatesPatient()
        {
            // Arrange
            var patient = new BuyerUpdateModel();
            var expected = new Buyer();
            
            var streetService = new Mock<ICityService>();
            streetService.Setup(x => x.ValidateAsync(patient));

            var patientDAL = new Mock<IBuyerDAL>();
            patientDAL.Setup(x => x.InsertAsync(patient)).ReturnsAsync(expected);

            var patientService = new BuyerService(patientDAL.Object, streetService.Object);
            
            // Act
            var result = await patientService.CreateAsync(patient);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_PatientValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var patient = new BuyerUpdateModel();
            var expected = fixture.Create<string>();
            
            var streetService = new Mock<ICityService>();
            streetService
                .Setup(x => x.ValidateAsync(patient))
                .Throws(new InvalidOperationException(expected));
            
            var patientDAL = new Mock<IBuyerDAL>();
            
            var patientService = new BuyerService(patientDAL.Object, streetService.Object);
            
            var action = new Func<Task>(() => patientService.CreateAsync(patient));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            patientDAL.Verify(x => x.InsertAsync(patient), Times.Never);
        }
    }
}