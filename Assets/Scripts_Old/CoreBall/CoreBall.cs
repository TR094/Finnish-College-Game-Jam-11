using Unity.VisualScripting;
using UnityEngine;

public class CoreBall : MonoBehaviour
{

    public Rigidbody2D PlayerRigidbod2D;
    float force = 10f;
    private float timer;



    GameController gameController;


    public PowerUpSpawner powerUpSpawner;
    public CoreRespawner coreRespawner;
    public LifeSystem lifeSystem;
    public ScoreSystem scoreSystem;

    int ballRotation;

    Vector2 movement;
    Vector2Int direction;

    int randomDirectionNumber;

    int[] directions = {40, 140, 220, 320}; // table for the ball directions

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        powerUpSpawner = FindFirstObjectByType<PowerUpSpawner>();
        gameController = FindFirstObjectByType<GameController>();
        coreRespawner = FindFirstObjectByType<CoreRespawner>();
        lifeSystem = FindFirstObjectByType<LifeSystem>();
        scoreSystem = FindFirstObjectByType<ScoreSystem>();

        Invoke("StartRandomBallMovement", 1);
    }


    public void StartRandomBallMovement()
    {
        randomDirectionNumber = Random.Range(0, 4);
        Debug.Log("pablo roation");
        ballRotation = directions[randomDirectionNumber]; // get random direction for the ball

        movement = new Vector2(powerUpSpawner.coreballspeed, 0).normalized;

        Debug.Log("it moves");

        Vector2 direction = Quaternion.Euler(0, 0, ballRotation) * Vector2.right; // add powerUpSpawner.coreballspeed to ball
        PlayerRigidbod2D.AddForce(direction, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("RandomWallUp"))
        {

            Vector2 v = PlayerRigidbod2D.linearVelocity;

            // Add small random angles
            float randomAngle = 20f;
            v = Quaternion.Euler(0, 0, randomAngle) * v;

            // Keep powerUpSpawner.coreballspeed constant
            PlayerRigidbod2D.linearVelocity = v.normalized * powerUpSpawner.coreballspeed;

        }

        if (collision.collider.CompareTag("RandomWallDown"))
        {

            Vector2 v = PlayerRigidbod2D.linearVelocity;

            // Add small random angles
            float randomAngle = 20f;
            v = Quaternion.Euler(0, 0, randomAngle) * v;

            // Keep powerUpSpawner.coreballspeed constant
            PlayerRigidbod2D.linearVelocity = v.normalized * powerUpSpawner.coreballspeed;

        }



        if (collision.collider.CompareTag("PlayerUp"))
        {
            scoreSystem.GainOneScore();

            Vector2 v = PlayerRigidbod2D.linearVelocity;

            // Add small random angles
            float randomAngle = 15f;
            v = Quaternion.Euler(0, 0, randomAngle) * v;

            // Keep powerUpSpawner.coreballspeed constant
            PlayerRigidbod2D.linearVelocity = v.normalized * powerUpSpawner.coreballspeed;
        }

        if (collision.collider.CompareTag("PlayerDown"))
        {
            scoreSystem.GainOneScore();

            Vector2 v = PlayerRigidbod2D.linearVelocity;

            // Add small random angles
            float randomAngle = -15f;
            v = Quaternion.Euler(0, 0, randomAngle) * v;

            // Keep powerUpSpawner.coreballspeed constant
            PlayerRigidbod2D.linearVelocity = v.normalized * powerUpSpawner.coreballspeed;
        }

        if (collision.collider.CompareTag("Walls"))
        {

            Vector2 v = PlayerRigidbod2D.linearVelocity;

            // Add small random angles
            float randomAngle = 0f;
            v = Quaternion.Euler(0, 0, randomAngle) * v;

            // Keep powerUpSpawner.coreballspeed constant
            PlayerRigidbod2D.linearVelocity = v.normalized * powerUpSpawner.coreballspeed;
            
            scoreSystem.GainOneScore();
        }

        if (collision.collider.CompareTag("CoreBall"))
        {

            Vector2 v = PlayerRigidbod2D.linearVelocity;

            // Add small random angles
            float randomAngle = 0f;
            v = Quaternion.Euler(0, 0, randomAngle) * v;

            // Keep powerUpSpawner.coreballspeed constant
            PlayerRigidbod2D.linearVelocity = v.normalized * powerUpSpawner.coreballspeed;
        }

        if (collision.transform.tag == "KillZone")
        {
            Debug.Log("osumaoli hyväFREEZEDOWN");
            lifeSystem.LoseOneLife();
            lifeSystem.NoLifesCheckFreezedown();
            coreRespawner.spawnCore();
            Destroy(GetComponent<SpriteRenderer>());
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(gameObject, 0);
        }

        if (collision.transform.tag == "KillZone2")
        {
            Debug.Log("osumaoli hyväMELTDOWN");
            lifeSystem.LoseOneLife();
            lifeSystem.NoLifesCheckMeltdown();
            coreRespawner.spawnCore();
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
        PlayerRigidbod2D.linearVelocity = PlayerRigidbod2D.linearVelocity.normalized * powerUpSpawner.coreballspeed; // MAKE SURE THE BALL MOVES AT A CONSTANT powerUpSpawner.coreballspeed
    }

}
