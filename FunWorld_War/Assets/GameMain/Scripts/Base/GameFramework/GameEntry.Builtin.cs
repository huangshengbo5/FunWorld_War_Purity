using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// ???????
/// </summary>
public partial class GameEntry : MonoBehaviour
{
    /// <summary>
    /// ???????????????
    /// </summary>
    public static BaseComponent Base { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static ConfigComponent Config { get; private set; }

    /// <summary>
    /// ??????????????
    /// </summary>
    public static DataNodeComponent DataNode { get; private set; }

    /// <summary>
    /// ?????????????
    /// </summary>
    public static DataTableComponent DataTable { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static DebuggerComponent Debugger { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static DownloadComponent Download { get; private set; }

    /// <summary>
    /// ???????????
    /// </summary>
    public static EntityComponent Entity { get; private set; }

    /// <summary>
    /// ???????????
    /// </summary>
    public static EventComponent Event { get; private set; }

    /// <summary>
    /// ?????????????
    /// </summary>
    public static FileSystemComponent FileSystem { get; private set; }

    /// <summary>
    /// ????????????????
    /// </summary>
    public static FsmComponent Fsm { get; private set; }

    /// <summary>
    /// ?????????????
    /// </summary>
    public static LocalizationComponent Localization { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static NetworkComponent Network { get; private set; }

    /// <summary>
    /// ?????????????
    /// </summary>
    public static ObjectPoolComponent ObjectPool { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static ProcedureComponent Procedure { get; private set; }

    /// <summary>
    /// ???????????
    /// </summary>
    public static ResourceComponent Resource { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static SceneComponent Scene { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static SettingComponent Setting { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static SoundComponent Sound { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static UIComponent UI { get; private set; }

    /// <summary>
    /// ????????????
    /// </summary>
    public static WebRequestComponent WebRequest { get; private set; }

    private static void InitBuiltinComponents()
    {
        Base = UnityGameFramework.Runtime.GameEntry.GetComponent<BaseComponent>();
        Config = UnityGameFramework.Runtime.GameEntry.GetComponent<ConfigComponent>();
        DataNode = UnityGameFramework.Runtime.GameEntry.GetComponent<DataNodeComponent>();
        DataTable = UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent>();
        Debugger = UnityGameFramework.Runtime.GameEntry.GetComponent<DebuggerComponent>();
        Download = UnityGameFramework.Runtime.GameEntry.GetComponent<DownloadComponent>();
        Entity = UnityGameFramework.Runtime.GameEntry.GetComponent<EntityComponent>();
        Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        FileSystem = UnityGameFramework.Runtime.GameEntry.GetComponent<FileSystemComponent>();
        Fsm = UnityGameFramework.Runtime.GameEntry.GetComponent<FsmComponent>();
        Localization = UnityGameFramework.Runtime.GameEntry.GetComponent<LocalizationComponent>();
        Network = UnityGameFramework.Runtime.GameEntry.GetComponent<NetworkComponent>();
        ObjectPool = UnityGameFramework.Runtime.GameEntry.GetComponent<ObjectPoolComponent>();
        Procedure = UnityGameFramework.Runtime.GameEntry.GetComponent<ProcedureComponent>();
        Resource = UnityGameFramework.Runtime.GameEntry.GetComponent<ResourceComponent>();
        Scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
        Setting = UnityGameFramework.Runtime.GameEntry.GetComponent<SettingComponent>();
        Sound = UnityGameFramework.Runtime.GameEntry.GetComponent<SoundComponent>();
        UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
        WebRequest = UnityGameFramework.Runtime.GameEntry.GetComponent<WebRequestComponent>();
    }
}