using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndMoveAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;
    public float spawnRate = 1.0f;
    
    private Vector2 cameraBounds;
    
    void Start()
    {
        cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log($"The camera bounds: {cameraBounds}");
        StartCoroutine(Spawn());
    }
    
    private void SpawnSingle()
    {
        GameObject a = Instantiate(asteroidPrefab);
        a.transform.position = new Vector3(-cameraBounds.x, 30f);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            SpawnSingle();
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
