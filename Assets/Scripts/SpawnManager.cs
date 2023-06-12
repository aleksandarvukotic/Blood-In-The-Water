using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] GameObject healthFishPrefab;

    float maxSpawnY = 1.1f;
    float minSpawnY = -1.1f;
    float xAxisSpawn = 3.2f;

    float startSpawnDelay = 3f;
    float spawnInterval = 1f;

    float minHealthSpawnDelay = 10f;
    float maxHealthSpawnDelay = 25f;

    private void Start()
    {
        InvokeRepeating("SpawnFood", startSpawnDelay, spawnInterval);
        StartCoroutine("SpawnHealthFish");
    }

    private void SpawnFood()
    {
        Vector3 spawnPos = new Vector3(xAxisSpawn, Random.Range(minSpawnY, maxSpawnY));

        Instantiate(foodPrefab, spawnPos, Quaternion.Euler(0,0,-90));
    }

    private IEnumerator SpawnHealthFish()
    {
        yield return new WaitForSeconds(Random.Range(minHealthSpawnDelay, maxHealthSpawnDelay));

        while (true)
        {
            Vector3 spawnPos = new Vector3(xAxisSpawn, Random.Range(minSpawnY, maxSpawnY));

            Instantiate(healthFishPrefab, spawnPos, Quaternion.Euler(0, 0, -90));

            yield return new WaitForSeconds(Random.Range(minHealthSpawnDelay, maxHealthSpawnDelay));
        }
    }
}
