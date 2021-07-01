using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private bool canInteract = false;
    private GameObject collisionObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionObject = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionObject = null;
    }

    private void Awake()
    {
        StartCoroutine(EnableInteraction());
    }

    private void Update()
    {
        if (collisionObject != null && canInteract)
        {
            if (Input.GetButtonDown("Fire1") && collisionObject.tag == "Interactable")
            {
                collisionObject.GetComponent<InteractiveObject>().Interact();
            }
        }
    }

    private IEnumerator EnableInteraction()
    {
        yield return new WaitForSeconds(1.0f);
        canInteract = true;
    }

    public void setCanInteract(bool CanInteract)
    {
        canInteract = CanInteract;
    }
}
