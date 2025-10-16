using UnityEngine;

public class WaterSpawner_Simple : MonoBehaviour
{
    public GameObject waterPrefab;   // 水块预制体
    public Transform spawnPoint;     // 出水位置
    public float spawnDelay = 0.5f;  // 出水间隔
    public float waterSpeed = 5f;    // 水块初速度

    private float timer = 0f;
    private bool isSpawning = false;

    void Update()
    {
        if (!isSpawning) return;

        timer += Time.deltaTime;
        if (timer >= spawnDelay)
        {
            timer = 0f;
            GameObject w = Instantiate(waterPrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody rb = w.GetComponent<Rigidbody>();
            if (rb != null)
                rb.linearVelocity = Vector3.down * waterSpeed;
            Destroy(w, 5f);
        }
    }

    // ▶️ 按钮：开/关水流
    public void ToggleWater()
    {
        isSpawning = !isSpawning;
    }

    // ⚡ 按钮：加速
    public void SpeedUp()
    {
        if (spawnDelay > 0.1f) spawnDelay -= 0.1f;
        waterSpeed += 1f;
    }

    // 🐢 按钮：减速
    public void SpeedDown()
    {
        spawnDelay += 0.1f;
        if (waterSpeed > 1f) waterSpeed -= 1f;
    }
}

