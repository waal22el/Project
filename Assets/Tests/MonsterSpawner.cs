using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs; 
    public Transform[] spawnPoints;     
    public float spawnInterval = 5f;   
    public int maxSpawnCount = 10;      

    private int spawnedCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnMonster), 2f, spawnInterval);
    }

    void SpawnMonster()
    {
        if (spawnedCount >= maxSpawnCount) return;
        
        GameObject monsterToSpawn = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(monsterToSpawn, spawnPoint.position, spawnPoint.rotation);
        spawnedCount++;
    }
}

