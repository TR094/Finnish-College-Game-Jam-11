using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UIElements;

public class Safe : MonoBehaviour, IPointerClickHandler
{
    public Sprite normalSprite;
    public Sprite openSprite;
    private Image image;

    [Header("Audio & Systems")]
    public AudioSource speaker;

    [Header("UI Canvas References")]
    [SerializeField] private GameObject keypadCanvas;
    [SerializeField] private TMP_InputField codeDisplay;

    [Header("Combination Settings")]
    [SerializeField] private int firstDigit = 0;
    [SerializeField] private int secondDigit = 5;
    [SerializeField] private int thirdDigit = 9;
    [SerializeField] private int fourthDigit = 4;

    public int safeOpenedCount = 1; // Tracks how many times the safe has been opened

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Prevent accidental multi-clicks if already open
        safeOpenedCount++;
    }


    public void Update()
    {
        if (safeOpenedCount % 2 == 1)
        {
            keypadCanvas.SetActive(true);
            string correctCombination = $"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit}";

            if (codeDisplay.text == correctCombination)
            {
                Debug.Log("Safe unlocked!");
                if (speaker != null) speaker.Play();

                safeOpenedCount = 1;
                image.sprite = openSprite;
            }
            else
            {
                Debug.Log("Incorrect combination.");
                image.sprite = normalSprite;
            }
        }
        else
        {
            keypadCanvas.SetActive(false);
        }

    }


}
