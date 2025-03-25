using GameFramework;

//强制定义不用资源类型的相对路径位置
//Todo 需要将当前的资源目录进行调整
public static class AssetUtility
{
    
    public static string GetConfigAssetPath(string assetName, bool fromBytes)
    {
        return Utility.Text.Format("Assets/GameMain/Configs/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
    }

    public static string GetDataTableAssetPath(string assetName, bool fromBytes)
    {
        return Utility.Text.Format("Assets/GameMain/DataTables/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
        //return Utility.Text.Format("Assets/GameMain/DataTables/Raw/{0}.{1}", assetName, fromBytes ? "bytes" : "txt");
    }

    public static string GetDictionaryAssetPath(string assetName, bool fromBytes)
    {
        return Utility.Text.Format("Assets/GameMain/Localization/{0}/Dictionaries/{1}.{2}",
            GameEntry.Localization.Language, assetName, fromBytes ? "bytes" : "xml");
    }

    public static string GetFontAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Fonts/{0}.ttf", assetName);
    }

    public static string GetSceneAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Scenes/{0}.unity", assetName);
    }

    public static string GetMusicAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Music/{0}.mp3", assetName);
    }

    public static string GetSoundAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Sounds/{0}.wav", assetName);
    }

    public static string GetEntityAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Entities/{0}.prefab", assetName);
    }

    public static string GetUIFormAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Res/Prefab/UI/{0}.prefab", assetName);
    }

    public static string GetUISoundAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/UI/UISounds/{0}.wav", assetName);
    }

    public static string GetBehaviorAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Res/BehaviorTree/{0}.asset", assetName);
    }

    public static string GetTextureAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Res/UI/Texture/{0}.png", assetName);
    }
    
    public static string GetModelAssetPath(string assetName)
    {
        return Utility.Text.Format("Assets/GameMain/Res/Prefab/Model/{0}.prefab", assetName);
    }
    public static string GetSoliderModelAssetPath()
    {
        return "Assets/GameMain/Res/Prefab/Solider/Solider.prefab";
    }

    public static string GetAbilityObjectSkillPath(int id)
    {
        return Utility.Text.Format("Assets/GameMain/Ability/AbilityObjects/Skill/Skill_{0}.asset", id);
    }

    public static string GetAbilityObjectBuffPath(int id)
    {
        return Utility.Text.Format("Assets/GameMain/Ability/AbilityObjects/Buff/Buff_{0}.asset", id);
    }

    public static string GetExecutionObjectPath(int id)
    {
        return Utility.Text.Format("Assets/GameMain/Ability/ExecutionObjects/Execution_{0}.asset", id);
    }
}