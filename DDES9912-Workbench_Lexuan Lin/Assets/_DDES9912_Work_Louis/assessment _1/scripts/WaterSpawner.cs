using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public GameObject waterBlockPrefab;  
    public Transform spawnPoint;          
    public float spawnInterval = 0.5f;    
    private bool isSpawning = false;

    
    public void ToggleSpawn()
    {
        isSpawning = !isSpawning;
        if (isSpawning)
            InvokeRepeating(nameof(SpawnWater), 0f, spawnInterval);
        else
            CancelInvoke(nameof(SpawnWater));
    }

    void SpawnWater()
    {
        Instantiate(waterBlockPrefab, spawnPoint.position, Quaternion.identity);
    }
}

