using UnityEngine;

namespace SyskenTLib.UtilForAndroid.Editor.Config
{

    public enum BundleVersionStorageType : int
    {
        ProjectSettings = 0,
        OriginalConfig=1
    }
    
    public class STUtilForAndroidConfig : ScriptableObject
    {
        
        [Header("どのバージョンバンドルを使う？")] [SerializeField] private BundleVersionStorageType _selectStorageType = BundleVersionStorageType.ProjectSettings;
        public BundleVersionStorageType GetSelectStorageType => _selectStorageType;
        
        [Header("ビルド時にバンドルバージョンを1上げるか")] [SerializeField] private bool _isEnableAutoUpBundleVersionOnBuild = false;
        public bool GetIsEnableAutoUpBundleVersionOnBuild => _isEnableAutoUpBundleVersionOnBuild;

    }
}