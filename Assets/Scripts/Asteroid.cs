using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    private Vector2 cameraBounds;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraBounds = Camera.main.ScreenToWorldPoint(new (Screen.width, Screen.height, Camera.main.transform.position.z));
        rb.velocity = new Vector3(-speed, 0);
    }

    void Update()
    {
        if (gameObject.transform.position.x < cameraBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
