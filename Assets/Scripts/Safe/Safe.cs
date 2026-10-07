using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Safe : MonoBehaviour, IPointerClickHandler
{
    [Header("Audio & Systems")]
    public AudioSource speaker;
    public HotbarSelector hotbarSelector; // Kept for your game systems context

    [Header("UI Canvas References")]
    [SerializeField] private GameObject keypadCanvas; // Drag your Keypad Canvas GameObject here
    [SerializeField] private TMP_InputField codeDisplay; // Drag the text display field here

    [Header("Combination Settings")]
    public int firstDigit = 0;
    public int secondDigit = 5;
    public int thirdDigit = 9;
    public int fourthDigit = 4;

    public bool keypadOpen = false; // Track if the keypad is currently open

    private string currentInput = "";

    private void Start()
    {
        CloseKeypad();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (keypadCanvas == null)
        {
            return;
        }

        keypadOpen = !keypadCanvas.activeSelf;
        keypadCanvas.SetActive(keypadOpen);
    }

    // Called by the "Enter / Submit" button on your UI, or via keyboard Enter
    public void SubmitCode()
    {
        string correctCombination = $"{firstDigit}{secondDigit}{thirdDigit}{fourthDigit}";

        if (currentInput == correctCombination)
        {
            Debug.Log("Safe unlocked!");
            speaker.Play();

            keypadCanvas.SetActive(false);
            keypadOpen = false;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Incorrect combination.");
            CloseKeypad();
        }
    }

    // Disables the canvas and syncs the state variable
    public void CloseKeypad()
    {
        if (keypadCanvas != null)
        {
            keypadCanvas.SetActive(false);
            keypadOpen = false;
        }
    }
}
