using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private GameObject spherePrefab;

    [Header("Spawn Settings")]
    [SerializeField] private int countPerType = 15;
    [SerializeField] private Vector2 spawnRangeX = new Vector2(-5f, 5f);
    [SerializeField] private Vector2 spawnRangeZ = new Vector2(-5f, 5f);
    [SerializeField] private float yPosition = 0.5f;

    void Start()
    {
        SpawnObjects(cubePrefab, countPerType);
        SpawnObjects(spherePrefab, countPerType);
    }

    void SpawnObjects(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(spawnRangeX.x, spawnRangeX.y),
                yPosition,
                Random.Range(spawnRangeZ.x, spawnRangeZ.y)
            );

            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}