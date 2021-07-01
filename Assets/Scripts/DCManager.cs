using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Dreamcatcher System
/// </summary>
public class DCManager : MonoBehaviour
{
    //The inaccessible room that the skinwalker can target to bring down the dreamcatcher
    [SerializeField]
    private Room dcRoom;

    //The Dreamcatcher in it's hanging state
    [SerializeField]
    private SpriteRenderer hangingSprite;

    //The Dreamcatcher in it's grounded state
    [SerializeField]
    private GameObject groundedSprite;

    private Skinwalker skinwalker;
    //Relative to the Dreamcatcher. If it's inactive, higher damage value, normal if active
    private float InactiveDamage = 2.0f, ActiveDamage = 1.0f;

    /// <summary>
    /// Sets the dreamcatcher as active by disabling the grounded version and then adding the Dreamcatcher room
    /// to the Skinwalker's room list
    /// </summary>
    private void Awake()
    {
        hangingSprite.enabled = true;
        groundedSprite.GetComponent<SpriteRenderer>().enabled = false;
        groundedSprite.GetComponent<BoxCollider2D>().enabled = false;
        skinwalker = FindObjectOfType<Skinwalker>();
        skinwalker.AddRoom(dcRoom, 2);
    }

    /// <summary>
    /// Deactivates the Dreamcatcher's effects. Is called by the DreamCatcherRoom child class when
    /// the Skinwalker targets it
    /// </summary>
    public void Deactivate()
    {
        Skinwalker.setMultiplier(InactiveDamage);
        hangingSprite.enabled = false;
        groundedSprite.GetComponent<SpriteRenderer>().enabled = true;
        groundedSprite.GetComponent<BoxCollider2D>().enabled = true;
    }

    /// <summary>
    /// Reactivates the Dreamcatcher's effects. Called by the Dreamcatcher Listener when the grounded
    /// sprite is clicked on
    /// </summary>
    public void Reactivate()
    {
        Skinwalker.setMultiplier(ActiveDamage);
        hangingSprite.enabled = true;
        groundedSprite.GetComponent<SpriteRenderer>().enabled = false;
        groundedSprite.GetComponent<BoxCollider2D>().enabled = false;
    }
}
