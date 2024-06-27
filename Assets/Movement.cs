using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] private float mainThrust = 5;
    [SerializeField] private float rotationThrust = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessInput();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * (mainThrust * Time.deltaTime));
            if(!audioSource.isPlaying)
                audioSource.Play();

            return;
        }
        
        audioSource.Pause();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThrust)
    {
        rb.freezeRotation = true;
        gameObject.transform.Rotate(Vector3.forward * (rotationThrust * Time.deltaTime));
        rb.freezeRotation = false;
    }
}
