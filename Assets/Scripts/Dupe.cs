using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject objectToSpawn; // Assign the part in Inspector
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 3f;

    [Header("Spawn Position Settings")]
    [SerializeField] private Vector2 spawnOffsetRange = new Vector2(0.5f, 0.5f); // Random offset in x and y

    private void Start()
    {
        if (objectToSpawn == null)
        {
            Debug.LogWarning("No object assigned to spawn!");
            return;
        }

        StartCoroutine(SpawnLoop());
    }

    private System.Collections.IEnumerator SpawnLoop()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            // Random spawn position near the spawner
            Vector3 spawnPos = transform.position + new Vector3(
                Random.Range(-spawnOffsetRange.x, spawnOffsetRange.x),
                Random.Range(-spawnOffsetRange.y, spawnOffsetRange.y),
                0f
            );

            // Spawn the object
            GameObject newObj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);

            // Unfreeze Rigidbody2D constraints if it exists
            Rigidbody2D rb = newObj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints2D.None; // Allow full movement
            }

            // Destroy after 2 seconds
            Destroy(newObj, 2f);
        }
    }
}
