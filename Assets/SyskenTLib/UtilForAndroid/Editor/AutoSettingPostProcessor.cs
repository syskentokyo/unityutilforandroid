using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace SyskenTLib.UtilForAndroid.Editor
{
    public class AutoSettingPostProcessor
    {
        
        [PostProcessBuild]
        public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
        {

            if (buildTarget == BuildTarget.Android)
            {
                
                //
                // パス系を控える処理
                //
                Debug.Log("APKパス："+path);

                UtilForAndroidManager utilForAndroidManager = new UtilForAndroidManager();
                utilForAndroidManager.SaveLastBuildAPKPath(path);
                
                
                string currentAppID = PlayerSettings.GetApplicationIdentifier(BuildTargetGroup.Android);
                Debug.Log("APKのアプリID："+currentAppID);
                utilForAndroidManager.SaveLastBuildAppID(currentAppID);
                
                
                //
                // ビルド時の処理開始
                //
                AndroidBuildManager androidBuildManager = new AndroidBuildManager();
                androidBuildManager.StartBuildCustom();
                
                
            }
        }
    }
}