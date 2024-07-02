using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndMoveAsteroidRandomly : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    
    private Vector2 cameraBounds;
    
    void Start()
    {
        cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(Spawn());
    }
    
    private void SpawnSingle()
    {
        GameObject a = Instantiate(asteroidPrefab);
        float size = Random.value * 4 + 1;
        float speed = Random.value * 30 + 10;
        float spawnHeight = Random.value * 45 + 4;
        a.transform.position = new Vector3(-cameraBounds.x, spawnHeight);
        asteroidPrefab.GetComponent<Asteroid>().speed = speed;
        asteroidPrefab.transform.localScale = new Vector3(size, size, size);
    }

    private IEnumerator Spawn()
    { 
        float spawnRate = 2f;

        while (true)
        {
            SpawnSingle();
            spawnRate = Random.value * 10 + 0.5f;
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
