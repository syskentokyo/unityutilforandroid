using UnityEditor;
using UnityEngine;

namespace SyskenTLib.UtilForAndroid.Editor.window
{
    public class RootWindow : UnityEditor.EditorWindow
    {
        /// <Summary>
        /// Rootの定義(らいぶらりごとにメニューに区切りをつけるためのダミー）
        /// </Summary>
        [MenuItem("SyskenTLib/UtilForAndroid/",priority = 40)]
        private static void OpenRoot()
        {
        }
        
        
        /// <summary>
        /// 最後にビルドしたAPKのパス出力
        /// </summary>
        [MenuItem("SyskenTLib/UtilForAndroid/ShowLastInstallAPKPath",priority = 100)]
        private static void ShowLastInstallAPKPath()
        {
#if UNITY_EDITOR && UNITY_ANDROID
            UtilForAndroidManager utilForAndroidManager = new UtilForAndroidManager();
            string lastPath = utilForAndroidManager.ReadLastBuildAPKPath();

            Debug.Log("最後にビルドしたAPK:"+lastPath);
            #endif
        }
        
        /// <summary>
        /// 最後にビルドしたAPKを再インストール
        /// </summary>
        [MenuItem("SyskenTLib/UtilForAndroid/ReInstallLastAPK",priority = 110)]
        private static void ReInstallAPK()
        {
            #if UNITY_EDITOR && UNITY_ANDROID
            UtilForAndroidManager utilForAndroidManager = new UtilForAndroidManager();
            string lastPath = utilForAndroidManager.ReadLastBuildAPKPath();

            if (lastPath != null && lastPath != "")
            {
                Debug.Log("再インストール開始："+lastPath);
                utilForAndroidManager.ADB_InstallAPK(lastPath);
                Debug.Log("再インストール完了："+lastPath);
                
                
                string appID = utilForAndroidManager.ReadLastBuildAPKAppID();
                Debug.Log("アプリ実行:"+appID);
                utilForAndroidManager.ADB_RunAPK(appID);


            }
            
            #endif
        }
    }
}