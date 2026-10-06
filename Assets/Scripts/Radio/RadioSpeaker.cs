using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RadioSpeaker : MonoBehaviour
{
    public float frequency; // Default frequency
    public Toggle radioToggle;
    public TMP_Text frequencyText;
    public bool powered = false;


    // implement the interface property (example backing field)

    void Start() { }

    void Update()
    {
        if (powered == true)
        {
            frequencyText.text = $"{frequency:F1} MHz";
        }
        else
        {
            frequencyText.text = $"";
        }

        if (frequency < 90.0f || frequency > 108.0f)
        {
            Debug.LogWarning("TETETSTESTESTESTESTST");
        }
        else
        {
            Debug.Log("NOOOOOOOOOOOOOOOOOOOOO");
        }

        if (radioToggle.isOn)
        {
            Debug.Log("Toggle is on");
        }
        else
        {
            Debug.Log("Toggle is off");
        }
    }
}
