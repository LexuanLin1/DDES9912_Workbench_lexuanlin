using TMPro;
using UnityEngine;

public class TextBlink : MonoBehaviour
{
    [Header("Text to Blink")]
    public TextMeshPro textObject;
    [Header("Blink Speed")]
    public float blinkSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (textObject == null) return;
        Color c = textObject.color;
        c.a = Mathf.PingPong(Time.time * blinkSpeed, 1f); // 0-1Ñ­»·
        textObject.color = c;
    }
}
