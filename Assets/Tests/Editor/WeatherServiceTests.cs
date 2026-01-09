using NUnit.Framework;
using WeatherApp.Services;

public class WeatherServiceTests
{
    [Test]
    public void BuildUrl_WithValidLatLon_ReturnsCorrectUrl()
    {
        // Arrange
        var service = new WeatherService();
        float lat = 26.4499f;
        float lon = 80.3319f;

        // Act
        string url = service.BuildUrl(lat, lon);

        // Assert
        Assert.IsTrue(url.Contains("latitude=26.4499"));
        Assert.IsTrue(url.Contains("longitude=80.3319"));
        Assert.IsTrue(url.Contains("daily=temperature_2m_max")
            || url.Contains("current_weather"));
    }
}
