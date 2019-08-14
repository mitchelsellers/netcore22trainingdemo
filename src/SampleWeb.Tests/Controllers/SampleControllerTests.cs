using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SampleWeb.Controllers;
using SampleWeb.Services.Samples;
using SampleWeb.Services.Samples.Models;
using Xunit;

namespace SampleWeb.Tests.Controllers
{
    public class SampleControllerTests
    {
        private readonly Mock<ISampleDataService> _sampleDataServiceMock;
        private readonly SampleController _sampleController;

        public SampleControllerTests()
        {
            _sampleDataServiceMock = new Mock<ISampleDataService>();
            _sampleController = new SampleController(_sampleDataServiceMock.Object);
        }

        [Fact]
        public void TestForm_ShouldReturnViewResult_WithDataServiceProvidedModel()
        {
            //Arrange
            var expectedResult = new FormWithFileViewModel();
            _sampleDataServiceMock.Setup(s => s.GetFormWithFileViewModel()).Returns(expectedResult).Verifiable();

            //Act
            var result = _sampleController.TestForm();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var actualModel = Assert.IsAssignableFrom<FormWithFileViewModel>(viewResult.Model);
            Assert.Equal(expectedResult, actualModel);
        }

        [Fact]
        public void TestFormPost_ShouldReturnViewResult_WithModel_WhenStateErrorsExist()
        {
            //Arrange
            var postedModel = new FormWithFileViewModel();
            _sampleController.ModelState.AddModelError(nameof(postedModel.FirstName), "Oops"); //Force error

            //Act
            var result = _sampleController.TestForm(postedModel);

            //Asset
            var viewResult = Assert.IsType<ViewResult>(result);
            var actualModel = Assert.IsType<FormWithFileViewModel>(viewResult.Model);
            Assert.Equal(postedModel, actualModel);
        }
    }
}
