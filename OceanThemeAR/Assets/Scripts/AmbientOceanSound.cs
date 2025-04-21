using UnityEngine;

public class AmbientOceanSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip audioClip = AudioClip.Create("AmbientOcean", 44100 * 2, 1, 44100, false); // Changed stream to false
        if (audioClip == null)
        {
            Debug.LogError("Failed to create AmbientOcean AudioClip in AmbientOceanSound.cs");
            return;
        }
        float[] samples = new float[44100 * 2];
        for (int i = 0; i < samples.Length; i++)
        {
            float noise = Mathf.PerlinNoise(i * 0.01f, 0) * 0.3f;
            samples[i] = Mathf.Sin(i * 0.05f) * 0.2f + noise;
        }
        audioClip.SetData(samples, 0);
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }
}
