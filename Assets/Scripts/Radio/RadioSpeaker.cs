using TMPro;
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
    public AudioSource speaker; // Your original single AudioSource
    public int batteryInside = 0; // no batteries
    public HotbarSelector hotbarSelector;

    public AudioClip staticNoise;
    public AudioClip channel1;
    public AudioClip channel2;
    public AudioClip channel3;
    public AudioClip channel4;

    [Header("Audio Implementation")]
    public float tuningTolerance = 0.5f;

    // Two dedicated run-time references to guarantee separation
    private AudioSource staticSource;
    private AudioSource channelSource;

    // Target frequencies for your channels
    private float channel1Freq = 93.1f;
    private float channel2Freq = 97.5f;
    private float channel3Freq = 102.3f;
    private float channel4Freq = 106.9f;

    public void OnPointerClick(PointerEventData eventData) { HandleClick(); }

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
    }

    void Start()
    {
        // GUARANTEE TWO SEPARATE AUDIO SOURCES:
        // Use the assigned inspector speaker for channels, or make one.
        channelSource = speaker != null ? speaker : gameObject.AddComponent<AudioSource>();

        // Always generate a totally unique AudioSource component just for the static loop.
        staticSource = gameObject.AddComponent<AudioSource>();

        // Initialize background loops independently
        if (staticSource != null && staticNoise != null)
        {
            staticSource.clip = staticNoise;
            staticSource.loop = true;
            staticSource.volume = 0f;
            staticSource.Play();
        }
        if (channelSource != null)
        {
            channelSource.loop = true;
            channelSource.volume = 0f;
            channelSource.Play();
        }
    }

    void Update()
    {
        if (batteryInside > 0 && radioToggle != null && radioToggle.isOn)
        {
            frequencyText.text = $"{frequency:F1} MHz";
            UpdateRadioAudio();
        }
        else
        {
            frequencyText.text = $"";
            MuteAllAudio();
        }
    }

    private void UpdateRadioAudio()
    {
        if (staticSource == null || channelSource == null) return;

        // Force static to stay alive and processing
        if (!staticSource.isPlaying && staticNoise != null)
        {
            staticSource.Play();
        }

        AudioClip targetClip = null;
        float distanceToStation = float.MaxValue;

        // Check proximity to channel frequencies
        if (Mathf.Abs(frequency - channel1Freq) <= tuningTolerance)
        {
            targetClip = channel1;
            distanceToStation = Mathf.Abs(frequency - channel1Freq);
        }
        else if (Mathf.Abs(frequency - channel2Freq) <= tuningTolerance)
        {
            targetClip = channel2;
            distanceToStation = Mathf.Abs(frequency - channel2Freq);
        }
        else if (Mathf.Abs(frequency - channel3Freq) <= tuningTolerance)
        {
            targetClip = channel3;
            distanceToStation = Mathf.Abs(frequency - channel3Freq);
        }
        else if (Mathf.Abs(frequency - channel4Freq) <= tuningTolerance)
        {
            targetClip = channel4;
            distanceToStation = Mathf.Abs(frequency - channel4Freq);
        }

        if (targetClip != null)
        {
            if (channelSource.clip != targetClip)
            {
                channelSource.clip = targetClip;
                channelSource.Play();
            }

            // Crossfade math
            float tuningFactor = Mathf.Clamp01(1f - (distanceToStation / tuningTolerance));
            channelSource.volume = tuningFactor;
            staticSource.volume = 1f - tuningFactor;
        }
        else
        {
            // PURE STATIC ZONE: Completely drop the station clip and mute the source channel
            if (channelSource.clip != null)
            {
                channelSource.Stop();
                channelSource.clip = null;
            }
            channelSource.volume = 0f;
            staticSource.volume = 1f;
        }
    }

    private void MuteAllAudio()
    {
        if (channelSource != null) channelSource.volume = 0f;
        if (staticSource != null) staticSource.volume = 0f;
    }
}
