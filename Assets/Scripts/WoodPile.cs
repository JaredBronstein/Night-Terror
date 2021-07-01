using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactive Object in the Game Room used to acquire wood to burn in the fireplace
/// </summary>
public class WoodPile : InteractiveObject
{
    private Fireplace fireplace;

    private void Awake()
    {
        fireplace = FindObjectOfType<Fireplace>();
    }

    public override void Interact()
    {
        Debug.Log("Fuel has been picked up!");
        fireplace.addFuel();
    }
}
