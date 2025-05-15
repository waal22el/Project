using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject[] bossPrefabs;  // L�gg in olika boss-prefabs h�r (FireBoss, IceBoss, osv.)
    public int numberOfBosses = 3;    // Hur m�nga bossar som ska placeras
    public Vector2 minSpawnPos;       // Nedre v�nstra h�rnet av dungeon
    public Vector2 maxSpawnPos;       // �vre h�gra h�rnet av dungeon

    void Start()
    {
        for (int i = 0; i < numberOfBosses; i++)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        // Slumpa en position inom angivet omr�de
        float x = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        float y = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        Vector2 spawnPosition = new Vector2(x, y);

        // Slumpa vilken boss-prefab som ska anv�ndas
        int bossIndex = Random.Range(0, bossPrefabs.Length);
        GameObject bossToSpawn = bossPrefabs[bossIndex];

        // Skapa bossen i scenen
        Instantiate(bossToSpawn, spawnPosition, Quaternion.identity);
    }
}

