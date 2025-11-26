using UnityEngine;

public class BridgeStepSound : MonoBehaviour
{
    public AudioSource stepSound;

    // Called when something enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if it is the player
        if (other.CompareTag("Player"))
        {
            if (!stepSound.isPlaying)
                stepSound.Play();
        }
    }
}
