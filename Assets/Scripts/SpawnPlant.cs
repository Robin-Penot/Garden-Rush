using UnityEngine;

public class SpawnPlant : MonoBehaviour
{
    public GameObject plantPrefab;
    public LayerMask groundLayer;
    public float minSpawnInterval = 10.0f;
    public float maxSpawnInterval = 15.0f;
    public int maxPlantCount = 10;
    private float spawnTimer = 0.0f;
    private int plantCount = 0;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (plantCount < maxPlantCount && spawnTimer >= Random.Range(minSpawnInterval, maxSpawnInterval))
        {
            Vector3 spawnPos = GetRandomGroundPos();
            Instantiate(plantPrefab, spawnPos, Quaternion.identity);
            spawnTimer = 0.0f;
            plantCount++;
        }
    }

    Vector3 GetRandomGroundPos()
    {
        Vector3 randomPos = new Vector3(Random.Range(-4.0f, 4.0f), 0, Random.Range(-4.0f, 4.0f));
        RaycastHit hit;
        if (Physics.Raycast(randomPos + Vector3.up * 10, Vector3.down, out hit, 20, groundLayer))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
