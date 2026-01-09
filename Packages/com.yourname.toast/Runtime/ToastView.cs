

using UnityEngine;
using ToastPackage.Interfaces;

namespace ToastPackage
{
    public class ToastView : MonoBehaviour
    {
        private IToastService toastService;

        private void Awake()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            toastService = new Android.AndroidToastService();
#elif UNITY_IOS && !UNITY_EDITOR
            toastService = new iOS.IOSToastService();
#else
            toastService = new EditorToastService();
#endif
        }

        public void Show(string message)
        {
            toastService?.Show(message);
        }
    }
}
