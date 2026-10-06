using UnityEngine;

public class handScript : MonoBehaviour
{
    public Sprite UpSprite;
    public Sprite DefaultSprite;
    public Sprite DownSprite;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = UpSprite;
        else if (Input.GetKey(KeyCode.S))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DownSprite;
        else
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DefaultSprite;

    }
}
