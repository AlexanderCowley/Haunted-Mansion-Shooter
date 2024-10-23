using UnityEngine;
using UnityEngine.SceneManagement;
public class ACSceneManagement : MonoBehaviour
{
    public static ACSceneManagement Instance;

    void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(this);
            return;
        }
    }

    public static void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void GoToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

}
