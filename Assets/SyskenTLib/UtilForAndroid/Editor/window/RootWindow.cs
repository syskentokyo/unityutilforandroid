using UnityEditor;

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
    }
}