using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Références aux 3 astéroïdes
    public GameObject shadowPrefab; // Préfab pour les ombres
    public int minAsteroids = 3; // Nombre minimum d'astéroïdes à choisir
    public int maxAsteroids = 5; // Nombre maximum d'astéroïdes à choisir
    public float spawnInterval = 10f; // Intervalle entre les apparitions
    public Vector3 spawnAreaMin = new Vector3(-10f, 10f, -10f); // Zone minimale de spawn
    public Vector3 spawnAreaMax = new Vector3(10f, 20f, 10f); // Zone maximale de spawn

    private List<GameObject> activeAsteroids = new List<GameObject>(); // Astéroïdes actifs
    private List<GameObject> activeShadows = new List<GameObject>(); // Ombres actives

    void Start()
    {
        StartCoroutine(SpawnAsteroidsRoutine());
    }

    void Update()
    {
    }

    IEnumerator SpawnAsteroidsRoutine()
    {
        while (true)
        {
            SpawnAsteroids();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnAsteroids()
    {
        int asteroidCount = Random.Range(minAsteroids, maxAsteroids);
        for (int i = 0; i < asteroidCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );

            GameObject asteroidPrefab = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
            if (asteroidPrefab != null)
            {
                GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
                activeAsteroids.Add(asteroid);

                // Optionally, instantiate a shadow for the asteroid
                if (shadowPrefab != null)
                {
                    GameObject shadow = Instantiate(shadowPrefab, spawnPosition, Quaternion.identity);
                    activeShadows.Add(shadow);
                }
            }
            else
            {
                Debug.LogError("Asteroid prefab is missing!");
            }
        }
    }
}