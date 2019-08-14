using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http.Internal;
using SampleWeb.Services.Samples;
using SampleWeb.Services.Samples.Models;
using Xunit;

namespace SampleWeb.Services.Tests.Samples
{
    public class SampleDataServiceTests
    {
        private readonly ISampleDataService _sampleDataService;

        public SampleDataServiceTests()
        {
            _sampleDataService = new SampleDataService();
        }

        [Fact]
        public void GetFormWithFileViewModel_ShouldReturnNotNullResult()
        {
            //Arrange

            //Act
            var result = _sampleDataService.GetFormWithFileViewModel();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetFormWithFileViewModel_ShouldReturnFormWithFileViewModel()
        {
            //Arrange
            
            //Act
            var result = _sampleDataService.GetFormWithFileViewModel();

            //Assert
            Assert.IsType<FormWithFileViewModel>(result);
        }

        [Fact]
        public void ProcessFormWithFileViewModel_ShouldReturnFalse_WhenImageIsNull()
        {
            //Arrange
            var model = new FormWithFileViewModel();

            //Act
            var result = _sampleDataService.ProcessFormWithFileViewModel(model);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void ProcessFormWithFileViewModel_ShouldReturnTrue_WhenImageIsNotNull()
        {
            //Arrange
            var model = new FormWithFileViewModel{ProfilePhoto = new FormFile(null, 0, 0, "", "")};

            //Act
            var result = _sampleDataService.ProcessFormWithFileViewModel(model);

            //Assert
            Assert.True(result);
        }
    }
}
