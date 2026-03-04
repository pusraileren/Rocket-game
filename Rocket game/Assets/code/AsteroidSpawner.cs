using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public float spawnRate = 2f;

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnAsteroid();
            timer = 0f;
        }
    }

    void SpawnAsteroid()
    {
        float randomX = Random.Range(-8f, 8f);

        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0);

        Instantiate(asteroid, spawnPosition, Quaternion.identity);
    }
}