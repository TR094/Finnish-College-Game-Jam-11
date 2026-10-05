using TMPro;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{

    public int Lifes;
    public TextMeshProUGUI LifeUI;


    GameController gameController;

    public void LoseOneLife()
    {
        Lifes -= 1;
    }

    public void GainOneLife()
    {
        Lifes += 1;
    }

    public void LoseTwoLifes()
    {
        Lifes -= 2;
    }

    public void GainTwoLifes()
    {
        Lifes += 2;
    }
    public void ResetLifes()
    {
        Lifes = 10;
    }

    public void NoLifesCheckMeltdown()
    {
        Debug.Log("Lifes" + Lifes);
        if (Lifes <= 0)
        {
            gameController.meltdownGameOver();
        }
        else
        {
        }
    }

    public void NoLifesCheckFreezedown()
    {
        Debug.Log("Lifes" + Lifes);
        if (Lifes <= 0)
        {
            gameController.freezedownGameOver();
        }
        else
        {
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        LifeUI.text = Lifes.ToString();
    }
}
