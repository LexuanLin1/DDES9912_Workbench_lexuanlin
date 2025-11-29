using UnityEngine;

public class WaterSplashController : MonoBehaviour
{
    public ParticleSystem splash;
    public Rigidbody wheelBody;

    private ParticleSystem.EmissionModule emission;

    void Start()
    {
        if (splash != null)
            emission = splash.emission;
    }

    void Update()
    {
        if (splash == null || wheelBody == null) return;

        float speed = wheelBody.angularVelocity.magnitude;

       
        emission.rateOverTime = Mathf.Lerp(0f, 40f, speed / 5f);
    }
}

