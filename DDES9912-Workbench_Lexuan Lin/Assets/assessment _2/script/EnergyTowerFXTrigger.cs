using UnityEngine;

public class EnergyTowerFXTrigger : MonoBehaviour
{
    public ParticleSystem burstFX;
    public ParticleSystem fireworksFX;
    public AudioSource boomSound;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;

        if (burstFX != null)
            burstFX.Play();

        if (fireworksFX != null)
            fireworksFX.Play();

        if (boomSound != null)
            boomSound.Play();

        Debug.Log("Energy Tower Activated!");
    }
}

