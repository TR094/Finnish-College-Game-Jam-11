using UnityEngine;

public class PowerUpSplit : MonoBehaviour
{
    public float Speed = 0.5f;
    public GameObject CoreBallPrefab;
    public float respawnTime = 1.0f;

    public Rigidbody2D PlayerRigidbod2D;

    public AudioClip negasplitFX;
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
            spawnCore();

            // play audio
            AudioSource.PlayClipAtPoint(negasplitFX, transform.position);

            Debug.Log("osumaoli IHAN HUONO");
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject, 0);
        }
    }




    // Update is called once per frame
    void Update()
    {

    }

    public void spawnCore()
    {
        GameObject a = Instantiate(CoreBallPrefab) as GameObject;
        a.transform.position = transform.localPosition;
    }
    void FixedUpdate()
    {
        PlayerRigidbod2D.linearVelocity = PlayerRigidbod2D.linearVelocity.normalized * Speed; // MAKE SURE THE BALL MOVES AT A CONSTANT SPEED
    }
}
