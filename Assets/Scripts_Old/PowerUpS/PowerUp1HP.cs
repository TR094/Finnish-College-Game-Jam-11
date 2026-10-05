using UnityEngine;

public class PowerUp1HP : MonoBehaviour
{
    public float Speed = 0.5f;
    public float respawnTime = 1.0f;


    public LifeSystem lifesystem;
    public Rigidbody2D PlayerRigidbod2D;

    public AudioClip posiupFX;
    public AudioSource powerAS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerAS = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "CoreBall")
        {
            lifesystem.GainOneLife();
            
            // play audio
            AudioSource.PlayClipAtPoint(posiupFX, transform.position);

            Debug.Log("osumaoli IHAN hyvä");
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        PlayerRigidbod2D.linearVelocity = PlayerRigidbod2D.linearVelocity.normalized * Speed; // MAKE SURE THE BALL MOVES AT A CONSTANT SPEED
    }
}
