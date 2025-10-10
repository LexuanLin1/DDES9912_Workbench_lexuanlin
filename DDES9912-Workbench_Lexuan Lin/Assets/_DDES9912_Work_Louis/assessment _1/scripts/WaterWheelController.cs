using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float torque = 5f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(Vector3.back * torque);
    }
}
