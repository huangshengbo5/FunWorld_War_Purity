using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static void GameEnter()
    {
        SceneManager.LoadScene(1);
    }
}