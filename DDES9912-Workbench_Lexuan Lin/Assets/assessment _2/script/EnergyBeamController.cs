using UnityEngine;

public class EnergyBeamController : MonoBehaviour
{
    public LineRenderer beam;
    public Rigidbody waterWheel;
    public Material beamMat;

    void Update()
    {
        if (beam == null || waterWheel == null) return;

        // Get wheel rotation speed
        float speed = waterWheel.angularVelocity.magnitude;

        // Map speed to beam intensity (0¨C10)
        float intensity = Mathf.Clamp(speed * 0.5f, 0f, 10f);

        // Update emission color based on speed
        Color baseColor = new Color(0f, 1f, 1f);
        Color finalColor = baseColor * intensity;

        beamMat.SetColor("_EmissionColor", finalColor);

        // Optional: Beam width grows with speed
        float width = Mathf.Lerp(0.05f, 0.2f, speed / 10f);
        beam.startWidth = width;
        beam.endWidth = width;
    }
}

