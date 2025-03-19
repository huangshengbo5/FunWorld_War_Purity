using GameFramework.ObjectPool;
using GameFramework.Resource;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SoliderFactory
{
    public class SoliderConfig
    {
        public int soliderId;
        public Vector3 position;
        public Vector3 size;
    }
    private int m_InstancePoolCapacity = 16;
    private GameObject m_SoliderTempate;
    private IObjectPool<SoliderPoolItem> m_SoliderObjectPool = null;
    public  void Initialization()
    {
        var SoliderPath = AssetUtility.GetSoliderModelAsset();
        
        var  m_LoadAssetCallbacks = new LoadAssetCallbacks((string assetName,object asset,float duration,object userData)=>
        {
            m_SoliderTempate = (GameObject)asset;
        }, null, null, null);
        GameEntry.Resource.LoadAsset(SoliderPath, m_LoadAssetCallbacks);
        m_SoliderObjectPool = GameEntry.ObjectPool.CreateSingleSpawnObjectPool<SoliderPoolItem>();
    }

    public Solider Create(Object obj)
    {
        Solider solider = null;
        SoliderPoolItem soliderPoolItem = m_SoliderObjectPool.Spawn();
        if (soliderPoolItem != null)
        {
            solider = (Solider)soliderPoolItem.Target;
        }
        else
        {
            var gameObject = GameObject.Instantiate(m_SoliderTempate);
            solider = gameObject.GetComponent<Solider>();
            m_SoliderObjectPool.Register(SoliderPoolItem.Create(solider),true);
        }
        return solider;
    }
    
    
}