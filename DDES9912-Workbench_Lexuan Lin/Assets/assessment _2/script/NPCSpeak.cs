using UnityEngine;

public class NPCSpeak : MonoBehaviour
{
    public AudioSource voice;

    public void Speak()
    {
        if (voice != null && !voice.isPlaying)
        {
            voice.Play();
        }
    }
}

