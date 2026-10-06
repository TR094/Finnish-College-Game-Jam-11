using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public LifeSystem LifeSystem;

    // music
    public AudioClip menuMusic;
    public AudioClip gameMusic;
    public AudioClip endMusic;

    public AudioSource bgmusicAS;

    //public GameObject Pause;
    //public GameObject Play;
    public GameObject FrozenDown;
    public GameObject MeltedDown;

    //public GameObject Lose;


    enum gamestate
    {
        playing,
        pause,
        freezedown,
        meltdown
    }

    gamestate currentstate = gamestate.playing;


    public void PlayState()
    {
        StateControl(gamestate.playing);
        LifeSystem.ResetLifes();


    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {

    }
    void Start()
    {
        startPlay();
        bgmusicAS = GetComponent<AudioSource>();
    }

    public void startPlay()
    {
        StateControl(gamestate.playing);

        LifeSystem.ResetLifes();

    }

    public void freezedownGameOver()
    {
        StateControl(gamestate.freezedown);

    }

    public void meltdownGameOver()
    {
        StateControl(gamestate.meltdown);

    }

    public void pauseState()
    {
        StateControl(gamestate.pause);
    }

    void StateControl(gamestate _gamestate)
    {


        currentstate = _gamestate;
        switch (currentstate)
        {


            case gamestate.playing:
                FrozenDown.SetActive(false);
                MeltedDown.SetActive(false);
                bgmusicAS.clip = gameMusic;
                bgmusicAS.Play();
                Time.timeScale = 1f;

                break;

            case gamestate.pause:
                Time.timeScale = 0f;

                break;


            case gamestate.freezedown:
                MeltedDown.SetActive(false);
                FrozenDown.SetActive(true);
                bgmusicAS.clip = endMusic;
                bgmusicAS.Play();
                Time.timeScale = 0f;

                break;

            case gamestate.meltdown:
                FrozenDown.SetActive(false);
                MeltedDown.SetActive(true);
                bgmusicAS.clip = endMusic;
                bgmusicAS.Play();
                Time.timeScale = 0f;

                break;


        }




    }


}
