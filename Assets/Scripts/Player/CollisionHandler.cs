using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 0.7f;
    [SerializeField] private AudioClip successAudioClip;
    [SerializeField] private AudioClip crashAudioClip;

    private AudioSource audioSource;
    private bool isTransitioning;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning)
            return;
        
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("You've reached finish. Should restart a scene.");
                StartFinishLevelSequence();
                break;
            case "Fuel":
                Debug.Log("You refilled the fuel.");
                break;
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            default:
                Debug.Log("Sorry, you blew up!");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashAudioClip);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", sceneLoadDelay);
    }

    void StartFinishLevelSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successAudioClip);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", sceneLoadDelay);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if(currentSceneIndex + 1 == SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(currentSceneIndex + 1);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
