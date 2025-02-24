using UnityEngine;

public partial class GameEntry : MonoBehaviour
{
    private void Start()
    {
        InitBuiltinComponents();
        InitCustomComponents();
        InitCustomDebuggers();
        DontDestroyOnLoad(this.gameObject);
    }
}