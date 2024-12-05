using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;

namespace KanzWay.Tests
{
    public class ScreeningControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ScreeningControllerTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData(1)]
        public async Task GetScreeningResults_ReturnsNumber_WhenNotDivisibleByThreeOrFive(int number)
        {
            // Arrange: Make a GET request to the API
            var response = await _client.GetAsync($"/api/v1/screening/{number}");

            // Act: Read the response content as a string
            var content = await response.Content.ReadAsStringAsync();

            // Deserialize the content into a List<string>
            var result = JsonConvert.DeserializeObject<List<string>>(content);

            // Assert: Verify the response is successful and contains the expected values
            response.StatusCode.Should().Be(HttpStatusCode.OK);  // Expecting HTTP 200 OK status
            response.IsSuccessStatusCode.Should().BeTrue(); // The status code is a success
            result.Should().Contain("1");
        }

        [Theory]
        [InlineData(3)]
        public async Task GetScreeningResults_ReturnsKanz_ForMultiplesOfThree(int number)
        {
            var response = await _client.GetAsync($"/api/v1/screening/{number}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(content);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.IsSuccessStatusCode.Should().BeTrue();
            result.Should().Contain("Kanz");
        }

        [Theory]
        [InlineData(5)]
        public async Task GetScreeningResults_ReturnsWay_ForMultiplesOfFive(int number)
        {
            var response = await _client.GetAsync($"/api/v1/screening/{number}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<string>>(content);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.IsSuccessStatusCode.Should().BeTrue();
            result.Should().Contain("Way");
        }

        [Theory]
        [InlineData(15)]
        public async Task GetScreeningResults_ReturnsKanzWay_ForMultiplesOfThreeAndFive(int number)
        {
            var response = await _client.GetAsync($"/api/v1/screening/{number}");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<string>>(content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.IsSuccessStatusCode.Should().BeTrue();
            result.Should().Contain("KanzWay");
        }

        [Fact]
        public async Task GetScreeningResults_ReturnsBadRequest_ForInvalidNumber()
        {
            // Arrange
            var response = await _client.GetAsync("/api/v1/screening/0");

            // Act
            var content = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            content.Should().Contain("Number Must Start 1");
        }
    }
}
