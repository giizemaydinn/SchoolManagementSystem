using AutoFixture;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Responses;
using Core.Utilities.Security.JWT;
using Entities.Dtos.User;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace Tests.Controller
{
    public class AuthControllerTests
    {
        readonly Mock<IAuthService> _authServiceMock;
        readonly IFixture _fixture;
        readonly AuthController _authController;

        public AuthControllerTests()
        {
            _fixture = new Fixture();
            _authServiceMock = _fixture.Freeze<Mock<IAuthService>>(); 
            _authController = new AuthController(_authServiceMock.Object);
        }

        [Fact]
        public async Task Login_ShouldBeReturnOk()
        {
            // Arrange
            var loginMock = _fixture.Create<UserForLoginDto>();

            var userMock = _fixture.Create<User>();
            var accessTokenMock = _fixture.Create<AccessToken>();

            var responseUserMock = _fixture.Create<Mock<IDataResponse<User>>>();
            responseUserMock.SetupGet(x => x.Success).Returns(true);
            responseUserMock.SetupGet(x => x.Message).Returns("test");
            responseUserMock.SetupGet(x => x.Data).Returns(userMock);

            var responseAccessTokenMock = new Mock<IDataResponse<AccessToken>>();
            responseAccessTokenMock.SetupGet(x => x.Success).Returns(true);
            responseAccessTokenMock.SetupGet(x => x.Message).Returns(Messages.AddStudent);
            responseAccessTokenMock.SetupGet(x => x.Data).Returns(accessTokenMock);

            var responseUser = responseUserMock.Object;
            var responseAccessToken = responseAccessTokenMock.Object;

            _authServiceMock
                .Setup(x => x.Login(loginMock))
                .ReturnsAsync(responseUser);

            _authServiceMock
                .Setup(x => x.CreateAccessToken(responseUser.Data))
                .ReturnsAsync(responseAccessToken);

            // Act
            var result = await _authController.Login(loginMock);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeAssignableTo<IDataResponse<AccessToken>>();
            okResult.Value.Should().BeEquivalentTo(responseAccessToken);
        }

    }
}
