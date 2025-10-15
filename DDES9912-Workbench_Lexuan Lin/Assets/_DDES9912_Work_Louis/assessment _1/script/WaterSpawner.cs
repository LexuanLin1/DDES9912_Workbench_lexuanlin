using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public GameObject waterBlockPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 0.5f;
    private bool spawning = false;
    private float timer = 0f;

    void Update()
    {
        if (!spawning) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Instantiate(waterBlockPrefab, spawnPoint.position, Quaternion.identity);
            timer = 0f;
        }
    }

    public void ToggleSpawn()
    {
        spawning = !spawning;
        Debug.Log("Water flow: " + (spawning ? "ON" : "OFF"));
    }
}

