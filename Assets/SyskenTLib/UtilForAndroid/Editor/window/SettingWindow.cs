using UnityEditor;
using UnityEngine;

namespace SyskenTLib.UtilForAndroid.Editor.window
{
    public class SettingWindow : EditorWindow
    {
        
        private bool isMustUpdate = true;

        private string androidAdbPath = "";
        private string currentIPAddress = "";
        private string currentPort = "";
        
        [MenuItem("SyskenTLib/UtilForAndroid/Setting",priority = 10)]
        private static void ShowWindow()
        {
            var window = GetWindow<SettingWindow>();
            window.titleContent = new GUIContent("UtilForAndroid - Setting");
            window.Show();
        }

        private void OnGUI()
        {
            if (isMustUpdate)
            {
                UtilForAndroidManager _utilForAndroidManager = new UtilForAndroidManager();
                androidAdbPath = _utilForAndroidManager.GetADBPath();
                isMustUpdate = false;
            }
            
            
            
            EditorGUILayout.BeginVertical("Box");
            if (GUILayout.Button("Update View"))
            {
                //表示更新
                isMustUpdate = true;
            }
            
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