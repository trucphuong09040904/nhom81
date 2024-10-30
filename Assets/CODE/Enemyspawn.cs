using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{
    public GameObject EnemyGO; // This is our enemy prefab

    float maxSpawnRateInSeconds = 5f;
    float timeSinceStart = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        // Cập nhật thời gian đã trôi qua
        timeSinceStart += Time.deltaTime;
    }

    // Function to spawn enemies
    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // Bottom-left point
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // Top-right point

        // Tính số lượng kẻ thù sẽ sinh ra dựa trên thời gian
        int enemyCount = Mathf.FloorToInt(timeSinceStart / 20) + 1; // Cứ 20 giây, thêm một kẻ thù mới

        for (int i = 0; i < enemyCount; i++)
        {
            // Instantiate an enemy
            GameObject anEnemy = Instantiate(EnemyGO);
            anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }

        // Schedule when to spawn the next batch of enemies
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    // Function to increase the difficulty of the game
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}
