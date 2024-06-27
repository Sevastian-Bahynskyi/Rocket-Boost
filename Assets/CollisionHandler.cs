using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        float sceneLoadDelay = 0.7f;
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("You've reached finish. Should restart a scene.");
                Invoke("LoadNextLevel", sceneLoadDelay);
                break;
            case "Fuel":
                Debug.Log("You refilled the fuel.");
                break;
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            default:
                Debug.Log("Sorry, you blew up!");
                Invoke("ReloadLevel", sceneLoadDelay);
                break;
        }
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
