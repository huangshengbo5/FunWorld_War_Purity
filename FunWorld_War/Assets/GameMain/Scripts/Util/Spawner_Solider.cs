using System.Collections;
using GameFramework.Resource;
using UnityEngine;

public class Spawner_Solider : MonoBehaviour
{
    public int Soldier_Id;

    private DRNPC NpcConfig;
    private void Start()
    {
        StartCoroutine(DelayLoadDataTable());
    }

    IEnumerator DelayLoadDataTable()
    {
        yield return new WaitForSeconds(1f);
        var NpcConfigs = GameEntry.DataTable.GetDataTable<DRNPC>();
        NpcConfig = NpcConfigs.GetDataRow(Soldier_Id);
        var ModelConfigs = GameEntry.DataTable.GetDataTable<DRModel>();
        var SoliderPath = AssetUtility.GetModelAsset(ModelConfigs.GetDataRow(NpcConfig.model).model);
        var  m_LoadAssetCallbacks = new LoadAssetCallbacks((string assetName,object asset,float duration,object userData)=>
        {
            CreateSolider((GameObject)asset);
        }, null, null, null);
        GameEntry.Resource.LoadAsset(SoliderPath, m_LoadAssetCallbacks);
    }
    
    protected GameObject CreateSolider(GameObject ObjSolider)
    {
        var solider = (GameObject)Instantiate(ObjSolider);
        solider.name = string.Format("Solider_{0}",Soldier_Id.ToString());
        var soliderTans = solider.GetComponent<Transform>();
        soliderTans.position = transform.position;
        soliderTans.localScale = Vector3.one;
        soliderTans.rotation = Quaternion.identity;
        var soliderCom = solider.GetComponent<Solider>();
        soliderCom.OwnerTown = null;
        soliderCom.SoliderId = Soldier_Id;
        return solider;
    }
}