using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameController : MonoBehaviour
{
    // Music
    public AudioClip menuAmbiance;
    public AudioClip gameMusic;
    public AudioClip endMusic;

    public AudioSource bgmusicAS;

    [Tooltip("Optional: plays the gameplay music with a custom loop point. If empty, Game Music plays on Bgmusic AS instead.")]
    public MusicLooper gameMusicLooper;

    // Ending screens
    public GameObject GoodEnding;
    public GameObject BadEnding;

    public GameObject hand;
    public GameObject screw;

    [Header("Bad ending sequence")]
    [Tooltip("UI Image that plays the overlay animation. Can be a child of the BadEnding panel.")]
    public Image gifOverlay;

    [Tooltip("The frames of the gif in order (import them as Sprites).")]
    public Sprite[] gifFrames;

    [Tooltip("Animation speed in frames per second.")]
    public float gifFps = 12f;

    [Tooltip("Seconds into the end music before the overlay animation starts (to sync with the audio).")]
    public float gifStartDelay = 13.3f;

    [Tooltip("Pause after the animation ends, before the fade starts.")]
    public float delayBeforeFade = 0.5f;

    [Tooltip("Full-screen black Image with a CanvasGroup, drawn on top of everything. Alpha 0 at the start.")]
    public CanvasGroup fadeToBlack;

    [Tooltip("How many seconds the fade to black takes.")]
    public float fadeDuration = 2f;

    [Header("Bad ending: shut down gameplay")]
    [Tooltip("Scripts to switch off when the ending starts, e.g. the player control scripts and the cursor-following script.")]
    public Behaviour[] disableOnEnding;

    [Tooltip("Objects to hide when the ending starts, e.g. the cursor sprite.")]
    public GameObject[] hideOnEnding;

    [Tooltip("Any other AudioSources (e.g. a separate background music player) to stop when the ending starts.")]
    public AudioSource[] stopOnEnding;

    [Header("Ending UI")]
    public GameObject endingButton;
    public float endingButtonDelay = 25f;

    bool badEndingStarted; // stops the sequence from starting twice

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
        hand.SetActive(true);
        screw.SetActive(true);
        // Only look for an AudioSource on this object if none was assigned in the Inspector.
        // (Before, this line overwrote the Inspector value with null when there was no AudioSource here.)
        if (bgmusicAS == null)
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
        Invoke(nameof(badEnding), 600f);
        StateControl(gamestate.playing);
    }

    public void goodEnding()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("GoodEnding");
    }

    public void badEnding()
    {
        
        StateControl(gamestate.badending);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void ReStartGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        Application.Quit();
    }

    void StateControl(gamestate state)
    {
        currentstate = state;

        switch (currentstate)
        {
            case gamestate.playing:

                // Hide endings
                if (GoodEnding != null) GoodEnding.SetActive(false);
                if (BadEnding != null) BadEnding.SetActive(false);

                // Play game music
                if (gameMusicLooper != null)
                {
                    gameMusicLooper.Play();
                }
                else if (bgmusicAS != null && gameMusic != null)
                {
                    bgmusicAS.clip = gameMusic;
                    bgmusicAS.loop = true;
                    bgmusicAS.Play();
                }

                break;

            case gamestate.badending:

                if (!badEndingStarted)
                {
                    badEndingStarted = true;
                    StartCoroutine(BadEndingSequence());
                }

                break;
        }
    }

    // Bad ending: show screen + music, play the overlay animation once, then fade to black.
    IEnumerator BadEndingSequence()
    {
        // Show bad ending
        if (GoodEnding != null) GoodEnding.SetActive(false);
        if (BadEnding != null) BadEnding.SetActive(true);

        // Start the ending immediately
        ShutDownGameplay();
        PlayEndMusic();

        // Start the 25-second button timer from this exact point
        StartCoroutine(ShowEndingButtonAfterDelay());

        yield return PlayOverlayAnimation();

        if (delayBeforeFade > 0f)
            yield return new WaitForSecondsRealtime(delayBeforeFade);

        yield return FadeToBlack();
    }

    IEnumerator ShowEndingButtonAfterDelay()
    {
        yield return new WaitForSecondsRealtime(endingButtonDelay);
        Cursor.visible = true;

        if (endingButton != null)
            endingButton.SetActive(true);
    }

    // Switches off player control, hides the cursor sprite and stops the normal music.
    void ShutDownGameplay()
    {
        foreach (Behaviour script in disableOnEnding)
            if (script != null) script.enabled = false;

        foreach (GameObject obj in hideOnEnding)
            if (obj != null) obj.SetActive(false);

        // Stop the normal background music (the end music starts right after this).
        if (gameMusicLooper != null) gameMusicLooper.Stop();
        if (bgmusicAS != null) bgmusicAS.Stop();

        foreach (AudioSource source in stopOnEnding)
            if (source != null) source.Stop();
    }

    void PlayEndMusic()
    {
        if (bgmusicAS == null)
        {
            Debug.LogWarning("GameController: no AudioSource assigned or found on this object, so the end music can't play.");
            return;
        }

        if (endMusic == null)
        {
            Debug.LogWarning("GameController: End Music clip is not assigned.");
            return;
        }

        bgmusicAS.clip = endMusic;
        bgmusicAS.loop = false; // the gameplay music fallback turns looping on
        bgmusicAS.Play();
    }

    // Waits gifStartDelay seconds into the end music, then plays the frames once (no looping)
    // and stays on the last frame.
    IEnumerator PlayOverlayAnimation()
    {
        hand.SetActive(false);
        screw.SetActive(false);
        if (gifOverlay == null || gifFrames == null || gifFrames.Length == 0)
            yield break;

        // Keep the overlay hidden until it's time.
        gifOverlay.gameObject.SetActive(false);
        gifOverlay.sprite = gifFrames[0];

        yield return WaitForMusicTime(gifStartDelay);

        gifOverlay.sprite = gifFrames[0];
        gifOverlay.gameObject.SetActive(true);

        // The frame is worked out from elapsed time (instead of waiting a fixed time per frame),
        // so the animation doesn't slowly drift out of sync with the audio.
        float fps = Mathf.Max(gifFps, 0.01f);
        float startTime = Time.unscaledTime;
        int shownFrame = -1;

        while (true)
        {
            int frame = Mathf.FloorToInt((Time.unscaledTime - startTime) * fps);
            if (frame >= gifFrames.Length)
                break;

            if (frame != shownFrame)
            {
                gifOverlay.sprite = gifFrames[frame];
                shownFrame = frame;
            }

            yield return null;
        }

        gifOverlay.sprite = gifFrames[gifFrames.Length - 1];
    }

    // Waits until the end music has played for 'seconds'. Follows the audio's own clock when it is
    // playing so the overlay stays in sync; otherwise falls back to a plain timer.
    IEnumerator WaitForMusicTime(float seconds)
    {
        if (seconds <= 0f)
            yield break;

        if (bgmusicAS != null && bgmusicAS.isPlaying && bgmusicAS.clip == endMusic)
        {
            while (bgmusicAS.isPlaying && bgmusicAS.time < seconds)
                yield return null;
        }
        else
        {
            yield return new WaitForSecondsRealtime(seconds);
        }
    }

    IEnumerator FadeToBlack()
    {
        if (fadeToBlack == null)
            yield break;

        fadeToBlack.gameObject.SetActive(true);
        fadeToBlack.blocksRaycasts = true; // block clicks on anything underneath while fading

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime; // works even if the game is paused with Time.timeScale = 0
            fadeToBlack.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }

        fadeToBlack.alpha = 1f;
        fadeToBlack.blocksRaycasts = false;
    }
}