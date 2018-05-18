using UnityEngine;
using UnityEngine.UI;
using System;
#if UNITY_IPHONE
using System.Runtime.InteropServices;
#endif

namespace U4S
{
    public class Unity4Swift : MonoBehaviour
    {
#if UNITY_IPHONE
        [DllImport("__Internal")] static extern void initPlugin(string gameObjectName);
        [DllImport("__Internal")] static extern void showAlertDialog(string title, string message, string button, string onClose);
#endif
        
        [SerializeField] Text text;

        void Start()
        {
#if !UNITY_EDITOR && UNITY_IPHONE
            initPlugin(gameObject.name);
#endif
        }

        public void ShowAlertDialog()
        {
#if !UNITY_EDITOR && UNITY_IPHONE
            var title   = "Unity4Swift";
            var message = "☆★☆Hello,swift!★☆★";
            var button  = "OK";
            var onClose = "OnClose";
            showAlertDialog(title, message, button, onClose);
#endif
        }
        
        void OnClose(string arg)
        {
            text.text = arg + " " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }
    }
}