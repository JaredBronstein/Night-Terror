using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used by the MouseTrigger object to store collision objects, check if they're interactive, then allow the player to click them
/// </summary>
public class InteractManager : MonoBehaviour
{
    private bool canInteract = false;
    private GameObject collisionObject;
    private GManager gManager;

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
        gManager = FindObjectOfType<GManager>();
        StartCoroutine(EnableInteraction());
    }

    /// <summary>
    /// If the player is hovering over an interactive object and clicks, interact with it.
    /// If the player is holding down click over the generator, switch to power up mode
    /// </summary>
    private void Update()
    {
        if (collisionObject != null && canInteract)
        {
            if (Input.GetButtonDown("Fire1") && collisionObject.tag == "Interactable")
            {
                collisionObject.GetComponent<InteractiveObject>().Interact();
            }
            else if (Input.GetButton("Fire1") && collisionObject.tag == "Generator")
            {
                gManager.PowerUp();
            }
        }

    }

    /// <summary>
    /// Buffer to prevent interaction spam
    /// </summary>
    private IEnumerator EnableInteraction()
    {
        yield return new WaitForSeconds(1.0f);
        canInteract = true;
    }

    /// <summary>
    /// Used by the Movement Controller to disable and enable during and after room transitions
    /// </summary>
    public void setCanInteract(bool CanInteract)
    {
        canInteract = CanInteract;
    }
}
