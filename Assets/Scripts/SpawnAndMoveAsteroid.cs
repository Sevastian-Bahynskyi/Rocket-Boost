using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndMoveAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    public float spawnRate = 1.0f;
    
    private Vector3 cameraBounds;
    
    void Start()
    {
        cameraBounds = Camera.current.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        StartCoroutine(Spawn());
    }
    
    private void SpawnSingle()
    {
        GameObject a = Instantiate(asteroidPrefab);
        a.transform.position = new Vector3(cameraBounds.x * 2, 30f);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnSingle();
        }
    }
}
