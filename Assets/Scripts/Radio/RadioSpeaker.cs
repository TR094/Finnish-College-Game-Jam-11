using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadioSpeaker : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public float frequency;
    public float frequencyChangePerPixel = 0.05f;
    public Transform knobSprite;
    public float knobRotationDegreesPerPixel = 1f;
    public Toggle radioToggle;
    public TMP_Text frequencyText;
    public AudioSource speaker;
    public int batteryInside = 0; // no batteries
    public bool antennaEquipped = false;
    public HotbarSelector hotbarSelector;

    public AudioSource channel1;

    public void OnPointerClick(PointerEventData eventData){HandleClick();}

    public void OnDrag(PointerEventData eventData)
    {
        if (hotbarSelector.itemEquipped == "Screwdriver")
        {
            frequency += eventData.delta.x * frequencyChangePerPixel;

            if (knobSprite != null)
            {
                knobSprite.Rotate(0f, 0f, -eventData.delta.x * knobRotationDegreesPerPixel);
            }
        }
    }

    private void HandleClick()
    {
        if (hotbarSelector != null && hotbarSelector.itemEquipped == "Clock")
        {
            batteryInside++;
        }
        //else if (hotbarSelector != null && hotbarSelector.itemEquipped == "antenna")
        //{
        //    antennaEquipped = true;
        //}

    }



    void Start() 
    {

    }

    void Update()
    {
        
        // Use Toggle.isOn rather than comparing the Toggle object to a bool
        if (batteryInside > 0 && radioToggle != null && radioToggle.isOn && antennaEquipped == false)
        {
            frequencyText.text = $"{frequency:F1} MHz";
            if (frequency < 90.0f || frequency > 108.0f)
            {
                Debug.LogWarning("TETETSTESTESTESTESTST");
            }
            else
            {
                Debug.Log("NOOOOOOOOOOOOOOOOOOOOO");
            }
        }
        else
        {
            frequencyText.text = $""; 
        }
    }
}
