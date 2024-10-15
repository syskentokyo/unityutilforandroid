using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.Callbacks;
using UnityEngine;

namespace SyskenTLib.UtilForAndroid.Editor
{
    public class AutoSettingPostProcessor:IPreprocessBuildWithReport, IPostprocessBuildWithReport
    {
        // 実行順
        public int callbackOrder => 1;
        

        // 事前実行
        public void OnPreprocessBuild(BuildReport report)
        {
            Debug.Log("OnPreprocessBuild　バンドルバージョンの処理");
            if (report.summary.platform == BuildTarget.Android)
            {
                
                //
                // パス系を控える処理
                //
                Debug.Log("APKパス："+report.summary.outputPath);

                UtilForAndroidManager utilForAndroidManager = new UtilForAndroidManager();
                utilForAndroidManager.SaveLastBuildAPKPath(report.summary.outputPath);
                
                
                string currentAppID = PlayerSettings.GetApplicationIdentifier(BuildTargetGroup.Android);
                Debug.Log("APKのアプリID："+currentAppID);
                utilForAndroidManager.SaveLastBuildAppID(currentAppID);
                
                
                //
                // ビルド時の処理開始
                //
                AndroidBuildManager androidBuildManager = new AndroidBuildManager();
                androidBuildManager.StartBuildCustom();
                
                AssetDatabase.Refresh (); // アセットDBの更新
            }
        }
        
        /// <summary>
        /// ビルド後
        /// </summary>
        /// <param name="report"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnPostprocessBuild(BuildReport report)
        {
        }

    }
}