using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject endPortal;
    private bool hasTeleported = false;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !hasTeleported)
        {
            hasTeleported = true;

            Debug.Log($"Rocket height: {other.transform.localScale.y}");
            Vector3 offset = Vector3.right * (other.transform.localScale.y  + 5);
            other.transform.position = endPortal.transform.position + offset;

            other.rigidbody.velocity = new Vector3(1, 0, 0);

            StartCoroutine(ResetTeleportFlag());
        }
    }

    private IEnumerator ResetTeleportFlag()
    {
        yield return new WaitForSeconds(0.3f);
        hasTeleported = false;
    }
}