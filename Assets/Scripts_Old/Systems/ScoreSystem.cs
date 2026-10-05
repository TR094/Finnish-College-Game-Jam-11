using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    public int Score;
    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI MeltdownLoseUI;
    public TextMeshProUGUI FreezedownLoseUI;


    //tee ok
    public void LoseOneScore()
    {
        Score -= 1;
    }

    public void GainOneScore()
    {
        Score += 1;
    }

    public void ResetScore()
    {
        Score = 0;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScoreUI.text = Score.ToString();
        MeltdownLoseUI.text = Score.ToString();
        FreezedownLoseUI.text = Score.ToString();
    }
}
