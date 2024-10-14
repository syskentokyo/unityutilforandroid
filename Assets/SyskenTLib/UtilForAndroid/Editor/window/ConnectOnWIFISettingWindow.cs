using UnityEditor;
using UnityEngine;

namespace SyskenTLib.UtilForAndroid.Editor.window
{
    public class ConnectOnWIFISettingWindow : EditorWindow
    {
        

        private string androidAdbPath = "";
        private string currentIPAddress = "";
        private string currentPort = "";
        
        [MenuItem("SyskenTLib/UtilForAndroid/Connect Device On WIFI",priority = 10)]
        private static void ShowWindow()
        {
            var window = GetWindow<ConnectOnWIFISettingWindow>();
            window.titleContent = new GUIContent("UtilForAndroid - ConnectOnDeviceWIFI");
            
            //パス設定
            UtilForAndroidManager _utilForAndroidManager = new UtilForAndroidManager();
            window.SetAndroidSDKPath( _utilForAndroidManager.GetADBPath());
            
            window.Show();
        }

        public void SetAndroidSDKPath(string newPath)
        {
            androidAdbPath = newPath;
        }

        private void OnGUI()
        {
            
            
            
            EditorGUILayout.BeginVertical("Box");
            
            EditorGUILayout.LabelField("Android SDK ADB Path");
            EditorGUILayout.TextArea(androidAdbPath);
            EditorGUILayout.Space(30);
            
            EditorGUILayout.LabelField("Connect TO Android Device On WIFI");
            EditorGUILayout.LabelField("IP Address");
            currentIPAddress= EditorGUILayout.TextArea(currentIPAddress);
            EditorGUILayout.LabelField("Port");
            currentPort=EditorGUILayout.TextArea(currentPort);
            if (GUILayout.Button("Connect"))
            {
                UtilForAndroidManager _utilForAndroidManager = new UtilForAndroidManager();
                _utilForAndroidManager.ADB_ChangeTCPIPMode();
                _utilForAndroidManager.ADB_ConnectToAndroidDevice(currentIPAddress,currentPort);
            }

            EditorGUILayout.EndVertical();
        }
    }
}