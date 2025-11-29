using UnityEngine;

public class EnergyTowerController : MonoBehaviour
{
    public Rigidbody waterWheel;
    public Material towerMat;

    void Update()
    {
        if (waterWheel == null || towerMat == null) return;

        float speed = waterWheel.angularVelocity.magnitude;
        float intensity = Mathf.Clamp(speed * 0.4f, 0f, 8f);

        // Energy tower brightness
        towerMat.SetColor("_EmissionColor", Color.cyan * intensity);
    }
}

