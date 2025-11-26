using UnityEngine;

public class WaterWheelGenerator : MonoBehaviour
{
    [Header("Wheel & Light")]
    public Rigidbody wheelBody;      // The water wheel rigidbody
    public Light lampLight;          // The lamp light component
    public Material emissiveMat;     // Emissive material on the bulb
    public float fadeSpeed = 2f;     // How fast light / sound reacts

    [Header("Sound")]
    public AudioSource wheelLoop;    // Looping wheel sound (water / creak)
    public AudioSource wheelStartSfx;// One-shot sound when wheel starts

    [Header("Tuning")]
    public float runThreshold = 0.2f;  // Minimum angular speed to count as "running"
    public float maxLightIntensity = 4f;

    private bool wasRunning = false;

    void Update()
    {
        if (wheelBody == null) return;

        // 1. Measure wheel speed
        float speed = wheelBody.angularVelocity.magnitude;

        // 2. Map speed to 0¨CmaxLightIntensity
        float intensity = Mathf.Clamp(speed * 1.5f, 0f, maxLightIntensity);

        // ---------- LIGHT ----------
        if (lampLight != null)
        {
            // Smoothly change lamp intensity
            lampLight.intensity = Mathf.Lerp(
                lampLight.intensity,
                intensity,
                Time.deltaTime * fadeSpeed
            );
        }

        // ---------- EMISSIVE COLOR ----------
        if (emissiveMat != null)
        {
            // Dark red when off  ->  yellow when fast
            Color dimColor = new Color(0.3f, 0f, 0f);   // dark red
            Color brightColor = Color.yellow;

            float t = Mathf.Clamp01(intensity / maxLightIntensity);
            Color c = Color.Lerp(dimColor, brightColor, t);

            float glow = Mathf.Lerp(0.5f, 4f, t);
            emissiveMat.SetColor("_EmissionColor", c * glow);
        }

        // ---------- SOUND ----------
        bool isRunning = speed > runThreshold;

        // Play one-shot when wheel just starts running
        if (!wasRunning && isRunning && wheelStartSfx != null)
        {
            wheelStartSfx.Play();
        }

        // Control looping wheel sound
        if (wheelLoop != null)
        {
            if (isRunning)
            {
                if (!wheelLoop.isPlaying)
                    wheelLoop.Play();

                // Volume follows wheel speed
                float targetVolume = Mathf.Clamp01(intensity / maxLightIntensity);
                wheelLoop.volume = Mathf.Lerp(
                    wheelLoop.volume,
                    targetVolume,
                    Time.deltaTime * fadeSpeed
                );
            }
            else
            {
                // Fade out when wheel stops
                wheelLoop.volume = Mathf.Lerp(
                    wheelLoop.volume,
                    0f,
                    Time.deltaTime * fadeSpeed
                );

                if (wheelLoop.volume < 0.01f)
                    wheelLoop.Stop();
            }
        }

        wasRunning = isRunning;
    }
}
