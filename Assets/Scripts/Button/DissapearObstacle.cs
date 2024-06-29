using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearObstacle : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    public void Dissapear()
    {
        obstacle.GetComponent<MeshRenderer>().enabled = false;
        obstacle.GetComponent<BoxCollider>().enabled = false;
    }
}
