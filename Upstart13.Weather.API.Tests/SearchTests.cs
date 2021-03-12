using Xunit;
using Upstart13.Weather.API.Controllers;
using Upstart13.Weather.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Upstart13.Weather.API.Tests
{

    public class SearchTests
    {
        [Theory]
        [InlineData("2075 West First Street, Fort Myers, FL")]
        [InlineData("250 Hartford Avenue, Bellingham MA 2019")]
        public async Task ValidAddressReturnsPeriods(string address)
        {
            var controller = new ForecastController(null);
            var actionResult = await controller.GetAsync(address);

            //Assert
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            //Assert
            ForecastResult FResult = JsonConvert.DeserializeObject<ForecastResult>(okObjectResult.Value.ToString());
            Assert.NotEmpty(FResult.properties.periods);


        }

        [Theory]
        [InlineData("jgfdgfdsgl gsdf ghjlksd")]
        [InlineData("a non valid US Address")]
        public async Task NonValidAddressReturnsNotFound(string address)
        {
            var controller = new ForecastController(null);
            var actionResult = await controller.GetAsync(address);

            //Assert
            var notFoundObjectResult = actionResult as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);

            //Assert
            Assert.Equal(404, notFoundObjectResult.StatusCode);

            //Assert
            Assert.Equal("Address not found", notFoundObjectResult.Value);
        }
    }
}

