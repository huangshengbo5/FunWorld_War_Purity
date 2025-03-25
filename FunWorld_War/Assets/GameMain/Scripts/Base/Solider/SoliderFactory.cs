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
        public Vector3 size = Vector3.one;

        public SoliderConfig(int soliderId, Vector3 position , Vector3 scale)
        {
            this.soliderId = soliderId;
            this.position = position;
            this.size = scale;
        }
    }
    private int m_InstancePoolCapacity = 16;
    private GameObject m_SoliderTempate;
    private IObjectPool<SoliderPoolItem> m_SoliderObjectPool = null;
    public  void Initialization()
    {
        var SoliderPath = AssetUtility.GetSoliderModelAssetPath();
        
        var  m_LoadAssetCallbacks = new LoadAssetCallbacks((string assetName,object asset,float duration,object userData)=>
        {
            m_SoliderTempate = (GameObject)asset;
        }, null, null, null);
        GameEntry.Resource.LoadAsset(SoliderPath, m_LoadAssetCallbacks);
        m_SoliderObjectPool = GameEntry.ObjectPool.CreateSingleSpawnObjectPool<SoliderPoolItem>();
    }

    public void Remove(Solider solider)
    {
        //回收对象
        m_SoliderObjectPool.Unspawn(solider);
    }
    
    public Solider Create(SoliderConfig soliderConfig)
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
            gameObject.name = $"Solider_{soliderConfig.soliderId}";
        }
        solider.gameObject.transform.position = soliderConfig.position;
        solider.gameObject.transform.localScale = soliderConfig.size;
        solider.Init(soliderConfig.soliderId);
        return solider;
    }
}