#if UNITY_ANDROID && !UNITY_EDITOR
using UnityEngine;
using ToastPackage.Interfaces;

namespace ToastPackage.Android
{
    public class AndroidToastService : IToastService
    {
        public void Show(string message)
        {
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

                activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    using (var toastClass = new AndroidJavaClass("android.widget.Toast"))
                    {
                        var context = activity.Call<AndroidJavaObject>("getApplicationContext");
                        var toast = toastClass.CallStatic<AndroidJavaObject>(
                            "makeText",
                            context,
                            message,
                            toastClass.GetStatic<int>("LENGTH_SHORT")
                        );
                        toast.Call("show");
                    }
                }));
            }
        }
    }
}
#endif
