using UnityEngine;

public class NPCProximityTalk : MonoBehaviour
{
    public AudioSource talkAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!talkAudio.isPlaying)
                talkAudio.Play();
        }
    }
}
