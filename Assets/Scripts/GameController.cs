using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Music
    public AudioClip menuAmbiance;
    public AudioClip gameMusic;
    public AudioClip endMusic;

    public AudioSource bgmusicAS;

    // Ending screens
    public GameObject GoodEnding;
    public GameObject BadEnding;

    enum gamestate
    {
        playing,
        pause,
        goodending,
        badending
    }

    gamestate currentstate = gamestate.playing;

    void Start()
    {
        // Get the AudioSource first
        bgmusicAS = GetComponent<AudioSource>();

        // Start the game
        startPlay();
    }

    public void PlayState()
    {
        StateControl(gamestate.playing);
    }

    public void startPlay()
    {
        StateControl(gamestate.playing);
    }

    public void goodEnding()
    {
        StateControl(gamestate.goodending);
    }

    public void badEnding()
    {
        StateControl(gamestate.badending);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Juuson älä koske");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");

        Application.Quit();
    }

    void StateControl(gamestate state)
    {
        currentstate = state;

        //switch (currentstate)
        //{
        //    case gamestate.playing:

        //        // Hide endings
        //        GoodEnding.SetActive(false);
        //        BadEnding.SetActive(false);

        //        // Play game music
        //        if (bgmusicAS != null && gameMusic != null)
        //        {
        //            bgmusicAS.clip = gameMusic;
        //            bgmusicAS.Play();
        //        }

        //        break;


        //    case gamestate.pause:

        //        // Pause music
        //        if (bgmusicAS != null)
        //        {
        //            bgmusicAS.Pause();
        //        }

        //        break;


        //    case gamestate.goodending:

        //        // Show good ending
        //        GoodEnding.SetActive(true);
        //        BadEnding.SetActive(false);

        //        // Play ending music
        //        if (bgmusicAS != null && endMusic != null)
        //        {
        //            bgmusicAS.clip = endMusic;
        //            bgmusicAS.Play();
        //        }

        //        break;


        //    case gamestate.badending:

        //        // Show bad ending
        //        GoodEnding.SetActive(false);
        //        BadEnding.SetActive(true);

        //        // Play ending music
        //        if (bgmusicAS != null && endMusic != null)
        //        {
        //            bgmusicAS.clip = endMusic;
        //            bgmusicAS.Play();
        //        }

        //        break;
        //}
    }
}
