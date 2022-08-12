using Microsoft.AspNetCore.Mvc;
using IneorTaskBackend.Controllers;
using IneorTaskBackend.Model.Login;
using IneorTaskBackend.Tests.Services;

namespace IneorTaskBackend.Tests.Tests.Controllers
{
    public class LoginControllerTest
    {
        private readonly LoginController _controller;
        private readonly LoginServiceFake _service;

        public LoginControllerTest()
        {
            _service = new LoginServiceFake();
            _controller = new LoginController(_service);
        }

        [Fact]
        public async void Login_DoesNotExist_ReturnsUnauthorized()
        {
            var result = await _controller.Login(new LoginRequest
            {
                Username = "invalid user",
                Password = "password",
            });

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async void Login_InvalidPassword_ReturnsUnauthorized()
        {
            var result = await _controller.Login(new LoginRequest
            {
                Username = "admin",
                Password = "password",
            });

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async void Login_CorrectCredentials_ReturnsObject()
        {
            var result = await _controller.Login(new LoginRequest
            {
                Username = "admin",
                Password = "admin",
            });

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
