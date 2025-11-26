using UnityEngine;

public class BridgeLiftWithSoundAnchors : MonoBehaviour
{
    [Header("References")]
    public Transform bridge;        // The bridge mesh to move
    public Transform bridgeDown;    // Target transform when bridge is down
    public Transform bridgeUp;      // Target transform when bridge is up
    public Rigidbody wheelBody;     // Water wheel rigidbody

    [Header("Settings")]
    public float speedThreshold = 0.2f;  // Wheel speed needed to lift the bridge
    public float moveSpeed = 2f;         // Lerp speed for moving the bridge

    [Header("Sound")]
    public AudioSource bridgeUpSfx;      // One-shot sound when bridge starts going up
    public AudioSource bridgeDownSfx;    // One-shot sound when bridge starts going down (optional)

    private bool isUp = false;
    private bool wasUp = false;

    void Start()
    {
        // If bridge is not assigned, use this GameObject's transform
        if (bridge == null)
            bridge = transform;

        // Start with bridge at down position if it exists
        if (bridgeDown != null)
            bridge.position = bridgeDown.position;
    }

    void Update()
    {
        if (wheelBody == null || bridgeDown == null || bridgeUp == null)
            return;

        // 1. Read wheel angular speed
        float wheelSpeed = wheelBody.angularVelocity.magnitude;

        // 2. Decide target state based on speed
        isUp = wheelSpeed > speedThreshold;

        // 3. Choose target transform
        Transform target = isUp ? bridgeUp : bridgeDown;

        // 4. Smoothly move bridge towards target
        bridge.position = Vector3.Lerp(
            bridge.position,
            target.position,
            Time.deltaTime * moveSpeed
        );

        // 5. Play sound on state change
        if (!wasUp && isUp && bridgeUpSfx != null)
        {
            // Bridge just started going up
            bridgeUpSfx.Play();
        }
        else if (wasUp && !isUp && bridgeDownSfx != null)
        {
            // Bridge just started going down
            bridgeDownSfx.Play();
        }

        wasUp = isUp;
    }
}
