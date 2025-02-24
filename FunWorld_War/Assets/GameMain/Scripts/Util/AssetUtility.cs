using GameFramework;

//强制定义不用资源类型的相对路径位置
//Todo 需要将当前的资源目录进行调整
public static class AssetUtility
{
    public static string GetConfigAsset(string assetName, bool fromBytes)
    {
        return Utility.Text.Format("Assets/GameMain/Configs/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
    }

    public static string GetDataTableAsset(string assetName, bool fromBytes)
    {
        return Utility.Text.Format("Assets/GameMain/DataTables/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        //return Utility.Text.Format("Assets/GameMain/DataTables/Raw/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
    }

    public static string GetDictionaryAsset(string assetName, bool fromBytes)
    {
        return Utility.Text.Format("Assets/GameMain/Localization/{0}/Dictionaries/{1}.{2}",
            GameEntry.Localization.Language, assetName, fromBytes ? "bytes" : "xml");
    }

    public static string GetFontAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Fonts/{0}.ttf", assetName);
    }

    public static string GetSceneAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
    }

    public static string GetMusicAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Music/{0}.mp3", assetName);
    }

    public static string GetSoundAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Sounds/{0}.wav", assetName);
    }

    public static string GetEntityAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Entities/{0}.prefab", assetName);
    }

    public static string GetUIFormAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Res/Prefab/UI/{0}.prefab", assetName);
    }

    public static string GetUISoundAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/UI/UISounds/{0}.wav", assetName);
    }

    public static string GetBehaviorAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Res/BehaviorTree/{0}.asset", assetName);
    }

    public static string GetTextureAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Res/UI/Texture/{0}.png", assetName);
    }
    
    public static string GetModelAsset(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Res/Prefab/Model/{0}.prefab", assetName);
    }
}