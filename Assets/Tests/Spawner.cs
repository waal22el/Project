using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Prefabs; 

    [SerializeField]
    private Transform[] spawnPoints; 

    
    [SerializeField]  
    private int givenSpawnCount = 1;

    [SerializeField] 
    private bool randomSpawn = true;

    [SerializeField]   
    private int SpawnRangeMin = 1;

    [SerializeField]  
    private int SpawnRangeMax = 10;    
    
    
    private bool hasSpawnedAllEnteties = false;

    void Start()
    {
        if(randomSpawn)
        {
            int randomSpawnCount = Random.Range(SpawnRangeMin, SpawnRangeMax);
            SpawnMonster(randomSpawnCount);
        }
        else
            SpawnMonster(givenSpawnCount);
    }

    void SpawnMonster(int entetiesToSpawn)
    {
        int spawnedCount = 0;
        while(!hasSpawnedAllEnteties)
        {
            GameObject monsterToSpawn = Prefabs[Random.Range(0, Prefabs.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(monsterToSpawn, spawnPoint.position, spawnPoint.rotation);
            spawnedCount++;

            if(spawnedCount == entetiesToSpawn)
                hasSpawnedAllEnteties = true;
        }
        
    
    }
}

