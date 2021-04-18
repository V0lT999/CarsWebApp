using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using CarsWebApp.BLL.Contracts;
using CarsWebApp.BLL.Implementation;
using CarsWebApp.DAL.Contracts;
using CarsWebApp.Domain;
using CarsWebApp.Domain.Models;
using NUnit.Framework;

namespace CarsWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class NoteServiceTest
    {
        [Test]
        public async Task CreateAsync_NoteValidationSucceed_CreatesNote()
        {
            // Arrange
            var note = new RequestUpdateModel();
            var expected = new Request();
            
            var patientService = new Mock<IBuyerService>();
            patientService.Setup(x => x.ValidateAsync(note));
            var doctorService = new Mock<IDealerService>();
            doctorService.Setup(x => x.ValidateAsync(note));
            var diseaseService = new Mock<ICarService>();
            diseaseService.Setup(x => x.ValidateAsync(note));
            
            var noteDAL = new Mock<IRequestDAL>();
            noteDAL.Setup(x => x.InsertAsync(note)).ReturnsAsync(expected);

            var noteService = new RequestService(noteDAL.Object, patientService.Object, doctorService.Object,diseaseService.Object);
            
            // Act
            var result = await noteService.CreateAsync(note);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_NoteValidationPatientFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new RequestUpdateModel();
            var expected = fixture.Create<string>();
            
            var patientService = new Mock<IBuyerService>();
            patientService.Setup(x => x.ValidateAsync(note))
                .Throws(new InvalidOperationException(expected));
            var doctorService = new Mock<IDealerService>();
            doctorService.Setup(x => x.ValidateAsync(note));
            var diseaseService = new Mock<ICarService>();
            diseaseService.Setup(x => x.ValidateAsync(note));

            
            var noteDAL = new Mock<IRequestDAL>();
            
            var noteService = new RequestService(noteDAL.Object, patientService.Object, doctorService.Object,diseaseService.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
        
        [Test]
        public async Task CreateAsync_NoteValidationDoctorFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new RequestUpdateModel();
            var expected = fixture.Create<string>();
            
            var patientService = new Mock<IBuyerService>();
            patientService.Setup(x => x.ValidateAsync(note));
            var doctorService = new Mock<IDealerService>();
            doctorService.Setup(x => x.ValidateAsync(note)) 
                .Throws(new InvalidOperationException(expected));
            var diseaseService = new Mock<ICarService>();
            diseaseService.Setup(x => x.ValidateAsync(note));

            
            var noteDAL = new Mock<IRequestDAL>();
            
            var noteService = new RequestService(noteDAL.Object, patientService.Object, doctorService.Object,diseaseService.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
        
        [Test]
        public async Task CreateAsync_NoteValidationDiseaseFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var note = new RequestUpdateModel();
            var expected = fixture.Create<string>();
            
            var patientService = new Mock<IBuyerService>();
            patientService.Setup(x => x.ValidateAsync(note));
            var doctorService = new Mock<IDealerService>();
            doctorService.Setup(x => x.ValidateAsync(note));
            var diseaseService = new Mock<ICarService>();
            diseaseService.Setup(x => x.ValidateAsync(note))
                .Throws(new InvalidOperationException(expected));

            
            var noteDAL = new Mock<IRequestDAL>();
            
            var noteService = new RequestService(noteDAL.Object, patientService.Object, doctorService.Object,diseaseService.Object);
            
            var action = new Func<Task>(() => noteService.CreateAsync(note));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            noteDAL.Verify(x => x.InsertAsync(note), Times.Never);
        }
    }
}