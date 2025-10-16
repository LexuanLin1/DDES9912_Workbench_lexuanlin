using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    [Header("Linked System")]
    public Rigidbody waterWheel;     
    public float speedStep = 0.5f;   
    public float minDrag = 0.1f;     
    public float maxDrag = 5f;       
    public Light indicatorLight;     

    private float currentDrag;

    void Start()
    {
        if (waterWheel != null)
            currentDrag = waterWheel.angularDamping;
    }

    public void SpeedUp()
    {
        if (waterWheel == null) return;

        currentDrag = Mathf.Max(minDrag, currentDrag - speedStep);
        waterWheel.angularDamping = currentDrag;

        UpdateLight(Color.green);
    }

    public void SpeedDown()
    {
        if (waterWheel == null) return;

        currentDrag = Mathf.Min(maxDrag, currentDrag + speedStep);
        waterWheel.angularDamping = currentDrag;

        UpdateLight(Color.red);
    }

    void UpdateLight(Color c)
    {
        if (indicatorLight != null)
        {
            indicatorLight.color = c;
            indicatorLight.intensity = 2f;
        }
    }
}

