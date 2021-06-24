using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
