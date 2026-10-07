using UnityEngine;

// Plays one music clip and loops it seamlessly from a custom point.
// Example: intro plays once, then the music repeats from 12.5s to 98.2s forever.
// Uses two AudioSources scheduled on the audio clock, so there is no gap or click at the loop point.
//
// Put this on its OWN empty GameObject (e.g. "MusicLooper"). It creates its AudioSources itself.
public class MusicLooper : MonoBehaviour
{
    [Tooltip("The music clip. Best as WAV or OGG with Load Type = 'Decompress On Load' (MP3 adds padding that can cause tiny gaps).")]
    public AudioClip clip;

    [Tooltip("Seconds. Every time the music reaches the loop end, it jumps back to this point. 0 = loop the whole clip.")]
    public float loopStartSeconds = 0f;

    [Tooltip("Seconds. Where the music jumps back from. 0 = the end of the clip.")]
    public float loopEndSeconds = 0f;

    [Range(0f, 1f)] public float volume = 1f;

    const double LookAhead = 0.5; // how many seconds ahead the next segment gets scheduled

    AudioSource[] sources;
    int nextSource;
    double nextSegmentStart; // audio-clock time when the next segment begins
    int loopStartSample;
    int loopEndSample;
    bool playing;

    void Awake()
    {
        sources = new AudioSource[2];
        for (int i = 0; i < sources.Length; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.loop = false;
            sources[i] = source;
        }
    }

    public void Play()
    {
        if (clip == null)
        {
            Debug.LogWarning("MusicLooper: no clip assigned.");
            return;
        }

        Stop();

        loopStartSample = Mathf.Clamp(Mathf.RoundToInt(loopStartSeconds * clip.frequency), 0, clip.samples - 1);
        loopEndSample = loopEndSeconds > 0f
            ? Mathf.Clamp(Mathf.RoundToInt(loopEndSeconds * clip.frequency), loopStartSample + 1, clip.samples)
            : clip.samples;

        foreach (AudioSource source in sources)
        {
            source.clip = clip;
            source.volume = volume;
        }

        nextSource = 0;
        nextSegmentStart = AudioSettings.dspTime + 0.1;

        // First pass starts at the very beginning (so the intro plays once)...
        ScheduleSegment(0);
        playing = true;
    }

    public void Stop()
    {
        playing = false;

        if (sources == null) return;
        foreach (AudioSource source in sources)
            source.Stop();
    }

    void Update()
    {
        if (!playing) return;

        // ...and every pass after that starts at the loop start point.
        if (AudioSettings.dspTime + LookAhead >= nextSegmentStart)
            ScheduleSegment(loopStartSample);
    }

    // Schedules one stretch of the clip (startSample -> loopEndSample) to begin exactly
    // when the previous stretch ends. The two AudioSources take turns.
    void ScheduleSegment(int startSample)
    {
        AudioSource source = sources[nextSource];
        double length = (double)(loopEndSample - startSample) / clip.frequency;

        source.timeSamples = startSample;
        source.PlayScheduled(nextSegmentStart);
        source.SetScheduledEndTime(nextSegmentStart + length);

        nextSegmentStart += length;
        nextSource = 1 - nextSource;
    }
}
