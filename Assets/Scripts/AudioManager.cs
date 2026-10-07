using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("Header")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio clip")]
    public AudioClip background;
    public AudioClip clock;
    public AudioClip lamp;

    public void Start()
    {
        musicSource.clip = background;
        musicSource.Play(); 
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
