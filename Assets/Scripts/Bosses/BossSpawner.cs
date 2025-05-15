using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject[] bossPrefabs;  // Lägg in olika boss-prefabs här (FireBoss, IceBoss, osv.)
    public int numberOfBosses = 3;    // Hur många bossar som ska placeras
    public Vector2 minSpawnPos;       // Nedre vänstra hörnet av dungeon
    public Vector2 maxSpawnPos;       // Övre högra hörnet av dungeon

    void Start()
    {
        for (int i = 0; i < numberOfBosses; i++)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        // Slumpa en position inom angivet område
        float x = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        float y = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        Vector2 spawnPosition = new Vector2(x, y);

        // Slumpa vilken boss-prefab som ska användas
        int bossIndex = Random.Range(0, bossPrefabs.Length);
        GameObject bossToSpawn = bossPrefabs[bossIndex];

        // Skapa bossen i scenen
        Instantiate(bossToSpawn, spawnPosition, Quaternion.identity);
    }
}

