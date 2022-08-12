using IneorTaskBackend.Model;
using Microsoft.AspNetCore.Mvc;
using IneorTaskBackend.Controllers;
using IneorTaskBackend.Tests.Services;

namespace IneorTaskBackend.Tests.Tests.Controllers
{
    public class BeachesControllerTest
    {
        private readonly BeachesController _controller;
        private readonly BeachesServiceFake _service;

        public BeachesControllerTest()
        {
            _service = new BeachesServiceFake();
            _controller = new BeachesController(_service);
        }

        #region Get

        [Fact]
        public async void Get_WhenCalled_ReturnsAllItems()
        {
            var items = await _controller.GetAll(0, 3, null, null);
            Assert.Equal(_service.Beaches.Count, items.Items.Count);
        }

        #endregion

        #region Get by ID

        [Fact]
        public async void GetById_DoesNotExist_ReturnsNotFound()
        {
            var notFound = await _controller.Get(Guid.NewGuid().ToString());
            Assert.IsType<NotFoundResult>(notFound.Result);
        }

        [Fact]
        public async void GetById_ExistingGuidPassed_ReturnsObject()
        {
            var id = _service.Beaches.First().Id;
            var result = await _controller.Get(id);
            Assert.IsType<Beach>(result.Value);
            Assert.Equal(result.Value?.Id, id);
        }

        #endregion

        #region Create

        [Fact]
        public async void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            var beach = new Beach
            {
                Id = Guid.NewGuid().ToString(),
                Name = "name 4",
                Description = "description 4",
                Country = "SI",
            };
            _controller.ModelState.AddModelError("ImageUrl", "Required");

            var badRequest = await _controller.Create(beach);
            Assert.IsType<BadRequestObjectResult>(badRequest.Result);
        }

        [Fact]
        public async void Add_AlreadyExists_ReturnsBadRequest()
        {
            var beach = new Beach
            {
                Id = _service.Beaches.First().Id,
                Name = "name 4",
                Description = "description 4",
                ImageUrl = "https://www.google.com",
                Country = "SI",
            };

            var badRequest = await _controller.Create(beach);
            Assert.IsType<BadRequestObjectResult>(badRequest.Result);
        }

        [Fact]
        public async void Add_ValidObjectPassed_ReturnsObject()
        {
            var beach = new Beach
            {
                Id = Guid.NewGuid().ToString(),
                Name = "name 4",
                Description = "description 4",
                ImageUrl = "https://www.google.com",
                Country = "SI",
            };

            var result = await _controller.Create(beach);
            Assert.IsType<Beach>(result.Value);
        }

        #endregion

        #region Update

        [Fact]
        public async void Update_DoesNotExist_ReturnsNotFound()
        {
            var beach = new Beach
            {
                Id = Guid.NewGuid().ToString(),
                Name = "name 4",
                Description = "description 4",
                ImageUrl = "https://www.google.com",
                Country = "SI",
            };

            var notFound = await _controller.Update(beach.Id, beach);
            Assert.IsType<NotFoundResult>(notFound.Result);
        }

        [Fact]
        public async void Update_InvalidObjectPassed_ReturnsBadRequest()
        {
            var beach = new Beach
            {
                Id = _service.Beaches.First().Id,
                Name = "name 4",
                Description = "description 4",
                Country = "SI",
            };
            _controller.ModelState.AddModelError("ImageUrl", "Required");

            var badRequest = await _controller.Update(beach.Id, beach);
            Assert.IsType<BadRequestObjectResult>(badRequest.Result);
        }

        [Fact]
        public async void Update_ValidObjectPassed_ReturnsObject()
        {
            var beach = new Beach
            {
                Id = _service.Beaches.First().Id,
                Name = "name 4",
                Description = "description 4",
                ImageUrl = "https://www.google.com",
                Country = "SI",
            };

            var result = await _controller.Update(beach.Id, beach);
            Assert.IsType<Beach>(result.Value);
        }

        #endregion

        #region Delete

        [Fact]
        public async void Remove_DoesNotExist_ReturnsNotFound()
        {
            var id = Guid.NewGuid().ToString();
            var notFound = await _controller.Delete(id);
            Assert.IsType<NotFoundResult>(notFound.Result);
        }

        [Fact]
        public async void Delete_ExistingGuidPassed_RemovesItemAndReturnsObject()
        {
            var newCount = _service.Beaches.Count - 1;
            var existingGuid = _service.Beaches.First().Id;
            var result = await _controller.Delete(existingGuid);

            Assert.Equal(newCount, _service.Beaches.Count);
            Assert.IsType<Beach>(result.Value);
        }

        #endregion
    }
}
