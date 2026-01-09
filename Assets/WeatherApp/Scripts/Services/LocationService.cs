

using System.Collections;
using UnityEngine;
#if UNITY_ANDROID
using UnityEngine.Android;
#endif

namespace WeatherApp.Services
{
    public class LocationService
    {
        public IEnumerator GetLocation(System.Action<float, float> onSuccess,
                                         System.Action<string> onError)
        {

            /*#if UNITY_EDITOR
                        // Mock location (Mumbai)
                        Debug.Log("Using mock location in Editor");
                        onSuccess?.Invoke(19.07f, 72.87f);
                        yield break;
            #endif*/
#if UNITY_EDITOR
            // Mock location (Kanpur)
            Debug.Log("Using mock location in Editor (Kanpur)");
            onSuccess?.Invoke(26.4499f, 80.3319f);
            yield break;
#endif

#if UNITY_ANDROID
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                Permission.RequestUserPermission(Permission.FineLocation);
                yield return null;
            }
#endif

            if (!Input.location.isEnabledByUser)
            {
                onError?.Invoke("Location permission not enabled");
                yield break;
            }

            Input.location.Start();

            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            if (maxWait <= 0)
            {
                onError?.Invoke("Location request timed out");
                yield break;
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                onError?.Invoke("Unable to determine location");
                yield break;
            }

            var data = Input.location.lastData;
            onSuccess?.Invoke(data.latitude, data.longitude);

            Input.location.Stop();
        }
    }
}
