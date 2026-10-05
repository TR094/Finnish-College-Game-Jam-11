using UnityEngine;

public class Players : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 7f;

    // audio
    public AudioClip paddleBounce;
    public AudioSource Player1AS;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player1AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.W))
            move = 1f;
        else if (Input.GetKey(KeyCode.S))
            move = -1f;

        rb.linearVelocity = new Vector2(0, move * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("CoreBall"))
        {
            // play audio
            Player1AS.PlayOneShot(paddleBounce);
        }
    }


}
