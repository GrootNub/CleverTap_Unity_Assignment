using System;

namespace WeatherApp.Models
{
    [Serializable]
    public class WeatherResponse
    {
        public DailyWeather daily;
    }

    [Serializable]
    public class DailyWeather
    {
        public string[] time;
        public float[] temperature_2m_max;
    }
}
