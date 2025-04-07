using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public enum SceneId :uint
{
    Battle_Test = 1,
    Ability_Test,
    Battle_Formal,
}
    
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnSceneConfig", order = 1)]
public class SceneConfig  : ScriptableObject
{
    [ShowInInspector] private List<SceneInfo> m_ScenceData;
    [ShowInInspector] private int Index;
    
    [System.Serializable]
    public class SceneInfo
    {
        public SceneId SceneId;
        public GameMode GameMode;
    }
    
    public List<SceneInfo> SceneData{get
    {
        return m_ScenceData;
    }}

    public GameMode GetGameMode(SceneId sceneId)
    {
        foreach (var item in m_ScenceData)
        {
            if (item.SceneId == sceneId)
            {
                return item.GameMode;
            }
        }
        return GameMode.Survival;
    }
    public void Save()
    {
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
}
