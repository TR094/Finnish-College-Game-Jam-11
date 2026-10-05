using UnityEngine;

public class PowerUpDestroyOwnself : MonoBehaviour
{
    public Rigidbody2D PlayerRigidbod2D;

    public float death;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("osumaoli IHAN HUONO");

        Destroy(gameObject, death);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
