using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Safe : MonoBehaviour, IPointerClickHandler
{
    [Header("Audio & Systems")]
    public AudioSource speaker;

    [Header("UI Canvas References")]
    [SerializeField] private GameObject keypadCanvas;
    [SerializeField] private TMP_InputField codeDisplay;
    [SerializeField] private GameObject SafeOpen;

    [Header("Combination Settings")]
    [SerializeField] private int firstDigit = 0;
    [SerializeField] private int secondDigit = 5;
    [SerializeField] private int thirdDigit = 9;
    [SerializeField] private int fourthDigit = 4;

    public int safeOpenedCount = 1; // Tracks how many times the safe has been opened

    private void Start()
    {
        SafeOpen.SetActive(false); // Enables the SafeOpen object
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
                gameObject.SetActive(false); // Disables the safe object
                SafeOpen.SetActive(true); // Enables the SafeOpen object
            }
            else
            {
                Debug.Log("Incorrect combination.");
            }
        }
        else
        {
            keypadCanvas.SetActive(false);
        }

    }


}
