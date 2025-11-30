using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EnvColorController : MonoBehaviour
{
    public Rigidbody waterWheel;        // reference to the waterwheel
    public Volume volume;              // reference to global volume

    ColorAdjustments colorAdjust;
    float baseExposure = -1f;
    float baseSaturation = -20f;

    void Start()
    {
        // Get Color Adjustment override
        if (volume.profile.TryGet(out colorAdjust) == false)
        {
            Debug.LogError("No ColorAdjustments found in Volume!");
        }
    }

    void Update()
    {
        if (waterWheel == null || colorAdjust == null) return;

        // get waterwheel rotation speed
        float speed = waterWheel.angularVelocity.magnitude;
        float t = Mathf.Clamp01(speed / 8f); // normalize 0¨C1

        // smoothly brighten environment
        colorAdjust.postExposure.value = Mathf.Lerp(baseExposure, 1f, t);

        // increase saturation for more ¡°energy¡±
        colorAdjust.saturation.value = Mathf.Lerp(baseSaturation, 30f, t);

        // color shifts from blue ¡ú cyan ¡ú bright yellow (feel ¡°charged¡±)
        Color startColor = new Color(0.4f, 0.6f, 1f);
        Color endColor = new Color(1f, 1f, 0.6f);
        colorAdjust.colorFilter.value = Color.Lerp(startColor, endColor, t);
    }
}

