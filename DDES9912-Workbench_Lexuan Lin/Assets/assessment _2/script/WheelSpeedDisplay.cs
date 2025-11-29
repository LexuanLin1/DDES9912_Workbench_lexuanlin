using TMPro;
using UnityEngine;

public class WheelSpeedDisplay : MonoBehaviour
{
    public Rigidbody wheel;
    public TextMeshProUGUI text;   
    public float showDistance = 100f;

    void Update()
    {
        if (wheel == null || text == null) return;

        float speed = wheel.angularVelocity.magnitude;

        text.text = "Waterwheel speed: " + speed.ToString("0.00");
    }
}

