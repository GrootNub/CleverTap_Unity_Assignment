#if UNITY_IOS && !UNITY_EDITOR
using ToastPackage.Interfaces;
using System.Runtime.InteropServices;

namespace ToastPackage.iOS
{
    public class IOSToastService : IToastService
    {
        [DllImport("__Internal")]
        private static extern void ShowIOSAlert(string message);

        public void Show(string message)
        {
            ShowIOSAlert(message);
        }
    }
}
#endif
