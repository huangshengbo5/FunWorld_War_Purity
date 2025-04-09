using System.Collections;
using GameFramework.Resource;
using UnityEngine;

public class Spawner_Town : MonoBehaviour
{
    public int TownId;
    private DRFortress townConfig;
    public int MaxHp = 10;
    public int DefaultMaxSoliderNum = 6;
    public CampType CampType;
    public int ViewRedius = 2;
    private void Start()
    {
        StartCoroutine(DelayLoadDataTable());
    }

    IEnumerator DelayLoadDataTable()
    {
        yield return new WaitForSeconds(1f);
        var townConfigs = GameEntry.DataTable.GetDataTable<DRFortress>();
        townConfig = townConfigs.GetDataRow(TownId);
        var townPath = AssetUtility.GetTownAssetPath();
        var  m_LoadAssetCallbacks = new LoadAssetCallbacks((string assetName,object asset,float duration,object userData)=>
        {
            CreateTown((GameObject)asset);
        }, null, null, null);
        GameEntry.Resource.LoadAsset(townPath, m_LoadAssetCallbacks);
    }
    
    protected GameObject CreateTown(GameObject ObjTown)
    {
        var town = (GameObject)Instantiate(ObjTown);
        town.name = string.Format("Town_{0}",TownId.ToString());
        var townTrans = town.GetComponent<Transform>();
        townTrans.position = transform.position;
        townTrans.localScale = Vector3.one;
        townTrans.rotation = Quaternion.identity;
        var townCom = town.GetComponent<Town>();
        townCom.campType = CampType;
        townCom.MaxHp = MaxHp;
        townCom.ViewRedius = ViewRedius;
        townCom.Init();
        return town;
    }
}