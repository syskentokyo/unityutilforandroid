using System.Diagnostics;
using UnityEditor;
using UnityEditor.Android;

namespace SyskenTLib.UtilForAndroid.Editor
{
    public class UtilForAndroidManager
    {

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
        }
        
        public void ADB_ConnectToAndroidDevice(string ipaddress,string port)
        {
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
        }
    }
}