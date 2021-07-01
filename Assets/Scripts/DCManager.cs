using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Dreamcatcher System
/// </summary>
public class DCManager : MonoBehaviour
{
    [SerializeField]
    private Room dcRoom;

    [SerializeField]
    private SpriteRenderer hangingSprite;

    [SerializeField]
    private GameObject groundedSprite;

    private Skinwalker skinwalker;
    private float InactiveDamage = 2.0f, ActiveDamage = 1.0f;

    private void Awake()
    {
        hangingSprite.enabled = true;
        groundedSprite.GetComponent<SpriteRenderer>().enabled = false;
        groundedSprite.GetComponent<BoxCollider2D>().enabled = false;
        skinwalker = FindObjectOfType<Skinwalker>();
        skinwalker.AddRoom(dcRoom, 2);
    }

    public void Deactivate()
    {
        Skinwalker.setMultiplier(InactiveDamage);
        hangingSprite.enabled = false;
        groundedSprite.GetComponent<SpriteRenderer>().enabled = true;
        groundedSprite.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void Reactivate()
    {
        Skinwalker.setMultiplier(ActiveDamage);
        hangingSprite.enabled = true;
        groundedSprite.GetComponent<SpriteRenderer>().enabled = false;
        groundedSprite.GetComponent<BoxCollider2D>().enabled = false;
    }
}
