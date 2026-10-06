using UnityEngine;

public class handScriptRight : MonoBehaviour
{
    public Sprite UpSprite;
    public Sprite DefaultSprite;
    public Sprite DownSprite;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.O))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = UpSprite;
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.K))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DownSprite;
        else
            this.gameObject.GetComponent<SpriteRenderer>().sprite = DefaultSprite;

    }
}
