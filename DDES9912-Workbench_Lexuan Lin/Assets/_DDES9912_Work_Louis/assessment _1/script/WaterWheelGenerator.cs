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
            Color c = Color.Lerp(Color.black, Color.yellow, intensity / 4f);
            emissiveMat.SetColor("_EmissionColor", c * intensity);
        }

        wheelBody.angularDamping = Mathf.Lerp(0.2f, 2f, lampLight.intensity / 4f);
    }
}

