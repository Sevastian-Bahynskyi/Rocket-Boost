using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndMoveAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    public float spawnRate = 1f;
    public float spawnHeight = 30f;
    public float spawnDelay = 0f;
    public float asteroidSpeed = 15f;
    
    private Vector2 cameraBounds;
    
    void Start()
    {
        cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log($"The camera bounds: {cameraBounds}");
        asteroidPrefab.GetComponent<Asteroid>().speed = asteroidSpeed;
        StartCoroutine(Spawn());
    }
    
    private void SpawnSingle()
    {
        GameObject a = Instantiate(asteroidPrefab);
        a.transform.position = new Vector3(-cameraBounds.x, spawnHeight);
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        while (true)
        {
            SpawnSingle();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
