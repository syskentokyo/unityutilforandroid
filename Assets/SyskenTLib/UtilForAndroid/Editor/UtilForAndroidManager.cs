using System.Diagnostics;
using UnityEditor;
using UnityEditor.Android;

namespace SyskenTLib.UtilForAndroid.Editor
{
    public class UtilForAndroidManager
    {

        private readonly string SAVE_KEY_LASTBUILD_PATH = "SyskenTLib.UtilForAndroid.Editor.LASTapkPathKey";
        private readonly string SAVE_KEY_LASTBUILD_APPID = "SyskenTLib.UtilForAndroid.Editor.LASTapkAppIDKey";

        #region 最後似にビルドしたAPK

        public void SaveLastBuildAPKPath(string apkPath)
        {
            EditorUserSettings.SetConfigValue(SAVE_KEY_LASTBUILD_PATH,apkPath);
        }
        
        public string ReadLastBuildAPKPath()
        {
            return EditorUserSettings.GetConfigValue(SAVE_KEY_LASTBUILD_PATH);
        }
        
        public void SaveLastBuildAppID(string appID)
        {
            EditorUserSettings.SetConfigValue(SAVE_KEY_LASTBUILD_APPID,appID);
        }
        
        public string ReadLastBuildAPKAppID()
        {
            return EditorUserSettings.GetConfigValue(SAVE_KEY_LASTBUILD_APPID);
        }

        #endregion
        

        public string GetAndroidSDKPath()
        {
            return AndroidExternalToolsSettings.sdkRootPath;
        }

        public string GetADBPath()
        {
            return GetAndroidSDKPath() + "/platform-tools/adb";
        }


        public void ADB_ChangeTCPIPMode()
        {
            #if UNITY_EDITOR_OSX
            string command = "-c \'" +GetADBPath() + " tcpip 5555"+"\'";
            
            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = command;
            process.Start();
            
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            process.Close();

            UnityEngine.Debug.Log(output);
            #elif  UNITY_EDITOR_WIN
            string command = "/c \"" +GetADBPath() + ".exe\"  tcpip 5555"+"";
            
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = command;
            process.Start();
            
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            process.Close();

            UnityEngine.Debug.Log(output);
            #endif
        }
        
        public void ADB_ConnectToAndroidDevice(string ipaddress,string port)
        {
#if UNITY_EDITOR_OSX
            string command = "-c '" +GetADBPath()+ " connect "+ ipaddress +":"+port+"'";
            
            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = command;
            process.Start();
            
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            process.Close();
            
            UnityEngine.Debug.Log(command);
            UnityEngine.Debug.Log(output);
#elif  UNITY_EDITOR_WIN
            string command = "/c \"" +GetADBPath()+ ".exe\"  connect "+ ipaddress +":"+port+"";
            
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = command;
            process.Start();
            
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            process.Close();
            
            UnityEngine.Debug.Log(command);
            UnityEngine.Debug.Log(output);

#endif
        }

        public void ADB_InstallAPK(string apkPath)
        {
#if UNITY_EDITOR_OSX
            string command = "-c '" + GetADBPath() + " install -r " + apkPath + "'";

            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = command;
            process.Start();

            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            process.Close();

            UnityEngine.Debug.Log(command);
            UnityEngine.Debug.Log(output);
#elif UNITY_EDITOR_WIN
            string command = "/c \"" +GetADBPath()+ ".exe\"   install -r  "+ apkPath +"'";
            
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = command;
            process.Start();
            
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            process.Close();
            
            UnityEngine.Debug.Log(command);
            UnityEngine.Debug.Log(output);

#endif
        }
        
        public void ADB_RunAPK(string appID)
        {
#if UNITY_EDITOR_OSX
            string command = "-c '" + GetADBPath() + " shell monkey  -p " + appID + " -c android.intent.category.LAUNCHER 1'";

            Process process = new Process();
            process.StartInfo.FileName = "/bin/bash";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = command;
            process.Start();

            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            process.Close();

            UnityEngine.Debug.Log(command);
            UnityEngine.Debug.Log(output);
#elif UNITY_EDITOR_WIN
            string command = "/c \"" +GetADBPath()+ ".exe\"   shell monkey  -p " + appID + " -c android.intent.category.LAUNCHER 1";
            
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = command;
            process.Start();
            
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            process.Close();
            
            UnityEngine.Debug.Log(command);
            UnityEngine.Debug.Log(output);

#endif
        }
    }
}