using System;
using System.IO;
using SyskenTLib.UtilForAndroid.Editor.Config;
using SyskenTLib.UtilForAndroid.Editor.JsonConfig;
using UnityEditor;
using UnityEngine;

namespace SyskenTLib.UtilForAndroid.Editor
{
    public class AndroidBuildManager
    {
        private readonly string SAVE_DIR_NAME = "SyskenTLibSetting";
        private readonly string SAVE_FILE_NAME = "utilforandroid_save.json";
        
        
        public void StartBuildCustom()
        {
            STUtilForAndroidConfig config  = GetConfig();
            
            //現在のバージョン取得
            int currentVersionOnProjectSetting = PlayerSettings.Android.bundleVersionCode;

            AndroidUtilJSONConfig savedJSONConfig = ReadAndroidUtilJSONConfig();//セーブデータ


            if (config.GetIsEnableAutoUpBundleVersionOnBuild == true)
            {
                //
                //ビルド時に、バンドルバージョンを上げる場合
                //

                int nextBundleVersion = 0;
                switch (config.GetSelectStorageType)
                {
                    case BundleVersionStorageType.ProjectSettings:
                        nextBundleVersion = currentVersionOnProjectSetting;
                        break;
                    case BundleVersionStorageType.OriginalConfig:
                        nextBundleVersion = savedJSONConfig._bundleVersion;
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                //バージョン上げる
                nextBundleVersion++;

                
                PlayerSettings.Android.bundleVersionCode = nextBundleVersion;;
                savedJSONConfig._bundleVersion = nextBundleVersion;
                savedJSONConfig._updateDateTxt =  DateTime.Now.ToLocalTime().ToString("yyyy/MM/dd_HH:mm:ss");
                
                //保存
                SaveAndroidUtilJSONConfig(savedJSONConfig);
                
                Debug.Log("Androidバージョンバンドルを変更 = "+nextBundleVersion);
            }



        }


        #region セーブファイル系

        private AndroidUtilJSONConfig ReadAndroidUtilJSONConfig()
        {
            string saveDirPath = GetSaveConfigDirPath();
            if (Directory.Exists(saveDirPath) == false)
            {
                //セーブディレクトリがなかったので作成
                Directory.CreateDirectory(saveDirPath);//ディレクトリ作成
            }
            
            string saveFilePath = GetSaveConfigFilePath();
            if (File.Exists(saveFilePath)==false)
            {
                //セーブファイルがなかったとき
                return new AndroidUtilJSONConfig();
            }

            string saveJSONTxt = File.ReadAllText(saveFilePath);
            
            AndroidUtilJSONConfig jsonConfig = JsonUtility.FromJson<AndroidUtilJSONConfig>(saveJSONTxt);
            return jsonConfig;

        }
        
        private void SaveAndroidUtilJSONConfig(AndroidUtilJSONConfig saveJSONConfig)
        {
            string saveDirPath = GetSaveConfigDirPath();
            if (Directory.Exists(saveDirPath) == false)
            {
                //セーブディレクトリがなかったので作成
                Directory.CreateDirectory(saveDirPath);//ディレクトリ作成
            }
            
            string saveFilePath = GetSaveConfigFilePath();
            string saveJSONTxt = JsonUtility.ToJson(saveJSONConfig, true);
            
            Debug.Log("Androidバージョンバンドルを保存"+saveJSONTxt);

            File.WriteAllText(saveFilePath, saveJSONTxt);
            

        }
        
        private string GetSaveConfigDirPath()
        {
            return Application.dataPath + "/../"+SAVE_DIR_NAME;
        }
        
        private string GetSaveConfigFilePath()
        {
            return GetSaveConfigDirPath()+"/"+SAVE_FILE_NAME;
        }
        

        #endregion


        #region  設定ファイル

        private string GetConfigPath()
        {
            string[] guids = AssetDatabase.FindAssets("t:STUtilForAndroidConfig");
            if (guids.Length != 1)
            {
                Debug.Log("ルート設定ファイルがありません。");
                return "";
            }

            string filePath = AssetDatabase.GUIDToAssetPath(guids[0]);

            return filePath;

        }
        
        
        private  STUtilForAndroidConfig GetConfig()
        {
            string rootConfigPath = GetConfigPath();
            if (rootConfigPath == "")
            {
                return null;
            }
            
            Debug.Log("コンフィグパス："+rootConfigPath);
            return AssetDatabase.LoadAssetAtPath<STUtilForAndroidConfig> (rootConfigPath);
           
        }
        #endregion        
        
    }
}