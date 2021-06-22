using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private GameObject collisionObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionObject = null;
    }

    private void Update()
    {
        if (collisionObject != null)
        {
            if (Input.GetButtonDown("Fire1") && collisionObject.tag == "Interactable")
            {
                Debug.Log(collisionObject.name + " has been interacted with.");
            }
        }
    }
}
