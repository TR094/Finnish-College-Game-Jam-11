using UnityEngine;

public class WallScript : MonoBehaviour
{
    public AudioClip wallBounce;
    public AudioSource wallAS;

    void Start()
    {

        wallAS = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("CoreBall"))
        {
            // play audio
            wallAS.PlayOneShot(wallBounce);
        }
    }
}
