using UnityEngine;

public class Players2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 7f;

    // audio
    public AudioClip paddleBounce;
    public AudioSource Player2AS;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player2AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.O))
            move = 1f;
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.K))
            move = -1f;

        rb.linearVelocity = new Vector2(0, move * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("CoreBall"))
        {
            // play audio
            Player2AS.PlayOneShot(paddleBounce);
        }
    }

}
