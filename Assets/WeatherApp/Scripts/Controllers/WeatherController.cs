using UnityEngine;
using WeatherApp.Services;
using ToastPackage;



namespace WeatherApp.Controllers
{
    public class WeatherController : MonoBehaviour
    {
        // private LocationService locationService;
        private WeatherApp.Services.LocationService locationService;

        private WeatherService weatherService;
        private ToastView toastView;

        private void Awake()
        {
            //locationService = new LocationService();
            locationService = new WeatherApp.Services.LocationService();

            weatherService = new WeatherService();
            toastView = FindObjectOfType<ToastView>();
        }

        public void OnGetWeatherClicked()
        {
            Debug.Log("onclicked");
            StartCoroutine(locationService.GetLocation(
                (lat, lon) =>
                {
                    StartCoroutine(weatherService.FetchWeather(
                        lat, lon,
                        temperature =>
                        {
                            toastView.Show(
                                $"Today's max temperature: {temperature}°C");
                        },
                        error =>
                        {
                            toastView.Show(error);
                        }));



                },
                error =>
                {
                    toastView.Show(error);
                }));
        }
    }
}
