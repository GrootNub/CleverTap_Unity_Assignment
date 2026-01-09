

using UnityEngine;
using ToastPackage.Interfaces;

namespace ToastPackage
{
    public class EditorToastService : IToastService
    {
        public void Show(string message)
        {
            Debug.Log($"[Toast] {message}");
        }
    }
}
