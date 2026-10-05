using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{

    GameController gameController;

    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
    }


    public void RestartGame()
    {
        Debug.Log("käynnistts uudelleen");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame()
    {
        gameController.pauseState();



    }

    public void ContinueGame()
    {

        gameController.PlayState();


    }

    public void StartGame()
    {
        gameController.PlayState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");

    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");

    }

    public void BackCredits()
    {
        Debug.Log("back to menu button pressed");
        SceneManager.LoadScene("Main Menu");

    }

    public void StartGameScene(string sceneName)
    {
        //SceneManager.LoadScene("SampleScene");
    }


    public void QuitGame()
    {
        Debug.Log("mennään pois");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
