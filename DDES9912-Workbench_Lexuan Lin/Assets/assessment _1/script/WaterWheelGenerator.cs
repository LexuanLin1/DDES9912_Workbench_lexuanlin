using UnityEngine;

public class WaterWheelGenerator : MonoBehaviour
{
    public Rigidbody wheelBody;
    public Light lampLight;
    public Material emissiveMat;
    public float fadeSpeed = 2f;


    void Update()
    {
        if (wheelBody == null) return;
        float speed = wheelBody.angularVelocity.magnitude;

        float intensity = Mathf.Clamp(speed * 1.5f, 0f, 4f);

        if (lampLight != null)
            lampLight.intensity = Mathf.Lerp(lampLight.intensity, intensity, Time.deltaTime * fadeSpeed);

        if (emissiveMat != null)
        {
            Color dimColor = Color.red;
            Color brightColor = Color.yellow;

            float t = Mathf.Clamp01(intensity / 4f);

            Color c = Color.Lerp(dimColor, brightColor, t);

            float glow = Mathf.Lerp(0.5f, 4f, t);

            emissiveMat.SetColor("_EmissionColor", c * glow);
        }


        wheelBody.angularDamping = Mathf.Lerp(0.2f, 2f, lampLight.intensity / 4f);
       
    }
}

