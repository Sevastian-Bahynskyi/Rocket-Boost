using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private float mainThrust = 5;
    [SerializeField] private float rotationThrust = 5;
    [SerializeField] private AudioClip engineAudioClip;
    [SerializeField] private ParticleSystem mainEngineEffect;
    [SerializeField] private ParticleSystem rightEngineEffect;
    [SerializeField] private ParticleSystem leftEngineEffect;
    
    private Rigidbody rb;
    private AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        ProcessThrust();
        ProcessInput();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
            StartThrusting();
        else
            StopThrusting();
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.A))
            RotateLeft();
        else if (Input.GetKey(KeyCode.D))
            RotateRight();
        else
            StopRotating();
    }
    
    
    private void StopThrusting()
    {
        audioSource.Pause();
        mainEngineEffect.Stop();
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * (mainThrust * Time.deltaTime));
        if(!audioSource.isPlaying)
            audioSource.PlayOneShot(engineAudioClip);
            
        if(!mainEngineEffect.isPlaying)
            mainEngineEffect.Play();
    }

    

    private void StopRotating()
    {
        leftEngineEffect.Stop();
        rightEngineEffect.Stop();
    }

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        if (!leftEngineEffect.isPlaying)
        {
            leftEngineEffect.Play();
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        if (!rightEngineEffect.isPlaying)
        {
            rightEngineEffect.Play();
        }
    }

    void ApplyRotation(float rotationThrust)
    {
        rb.freezeRotation = true;
        gameObject.transform.Rotate(Vector3.forward * (rotationThrust * Time.deltaTime));
        rb.freezeRotation = false;
    }
}
