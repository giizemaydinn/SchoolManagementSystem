using AutoFixture;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Responses;
using Entities.Dtos.Student;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace Tests.Controller
{
    public class StudentsControllerTests
    {
        readonly Mock<IStudentService> _studentServiceMock;
        readonly IFixture _fixture;
        readonly StudentsController _studentsController;

        public StudentsControllerTests()
        {
            _fixture = new Fixture();
            _studentServiceMock = _fixture.Freeze<Mock<IStudentService>>(); 
            _studentsController = new StudentsController(_studentServiceMock.Object);
        }


        [Fact]
        public async Task GetAll_ShouldReturnStudentDetails()
        {
            // Arrange
            var students = _fixture.CreateMany<StudentDetailDto>(10).ToList();

            var responseMock = _fixture.Create<Mock<IDataResponse<IEnumerable<StudentDetailDto>>>>();
            responseMock.SetupGet(x => x.Data).Returns(students);
            responseMock.SetupGet(x => x.Success).Returns(true);
            responseMock.SetupGet(x => x.Message).Returns(Messages.GetAllStudent);

            var response = responseMock.Object;

            _studentServiceMock
                .Setup(x => x.GetAll())
                .ReturnsAsync(response);

            // Act
            var result = await _studentsController.GetAll();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeAssignableTo<IDataResponse<IEnumerable<StudentDetailDto>>>();
            okResult.Value.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task GetById_ShouldReturnStudentDetail()
        {
            // Arrange
            var studentDetail = _fixture.Create<StudentDetailDto>();

            var responseMock = _fixture.Create<Mock<IDataResponse<StudentDetailDto>>>();
            responseMock.SetupGet(x => x.Data).Returns(studentDetail);
            responseMock.SetupGet(x => x.Success).Returns(true);
            responseMock.SetupGet(x => x.Message).Returns(Messages.GetStudent);

            var response = responseMock.Object;

            _studentServiceMock
                .Setup(x => x.GetById(studentDetail.Id))
                .ReturnsAsync(response);

            // Act
            var result = await _studentsController.GetById(studentDetail.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeAssignableTo<IDataResponse<StudentDetailDto>>();
            okResult.Value.Should().BeEquivalentTo(response);
        }

        [Fact]
        public async Task Add_ShouldBeReturnOk()
        {
            // Arrange
            var addStudentDto = _fixture.Create<AddStudentDto>();

            var responseMock = _fixture.Create<Mock<IResponse>>();
            responseMock.SetupGet(x => x.Success).Returns(true);
            responseMock.SetupGet(x => x.Message).Returns(Messages.AddStudent);

            var response = responseMock.Object;

            _studentServiceMock
                .Setup(x => x.Add(addStudentDto))
                .ReturnsAsync(response);

            // Act
            var result = await _studentsController.Add(addStudentDto);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeAssignableTo<IResponse>();
            okResult.Value.Should().BeEquivalentTo(response);
        }


    }
}
