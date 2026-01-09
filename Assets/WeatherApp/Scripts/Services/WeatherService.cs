using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private const string BaseUrl =
            "https://api.open-meteo.com/v1/forecast";

        public string BuildUrl(float lat, float lon)
        {
            return $"{BaseUrl}?latitude={lat}&longitude={lon}&timezone=IST&daily=temperature_2m_max";
        }

        /* public IEnumerator FetchWeather(float lat, float lon,
             System.Action<float> onSuccess,
             System.Action<string> onError)
         {
             string url = BuildUrl(lat, lon);

             using (UnityWebRequest request = UnityWebRequest.Get(url))
             {
                 yield return request.SendWebRequest();

                 if (request.result != UnityWebRequest.Result.Success)
                 {
                     onError?.Invoke(request.error);
                     yield break;
                 }

                 WeatherResponse response =
                     JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text);

                 if (response?.daily?.temperature_2m_max == null ||
                     response.daily.temperature_2m_max.Length == 0)
                 {
                     onError?.Invoke("Invalid weather data");
                     yield break;
                 }

                 // Use today's max temperature
                 onSuccess?.Invoke(response.daily.temperature_2m_max[0]);
             }
         }*/

        public IEnumerator FetchWeather(
    float lat,
    float lon,
    System.Action<float> onSuccess,
    System.Action<string> onError)
        {
            string url = BuildUrl(lat, lon);

            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    onError?.Invoke(request.error);
                    yield break;
                }

              
                Debug.Log("Weather API URL: " + url);
                Debug.Log("Weather API JSON: " + request.downloadHandler.text);

                WeatherResponse response =
                    JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text);

                if (response?.daily?.temperature_2m_max == null ||
                    response.daily.temperature_2m_max.Length == 0)
                {
                    onError?.Invoke("Invalid weather data");
                    yield break;
                }

                onSuccess?.Invoke(response.daily.temperature_2m_max[0]);
            }
        }

    }
}
