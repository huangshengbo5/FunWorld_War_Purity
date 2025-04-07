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
    [ShowInInspector] private Dictionary<SceneId, GameMode> m_ScenceData;
    
    public Dictionary<SceneId,GameMode> SceneData{get
    {
        return m_ScenceData;
    }}

    public void Save()
    {
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
    }
}
