using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Interactive Object child attached to the fallen dreamcatcher object. Links to Dreamcatcher Manager so when interacting it'll reactive it
/// </summary>
public class DCListener : InteractiveObject
{
    private DCManager dcManager;

    private void Awake()
    {
        dcManager = FindObjectOfType<DCManager>();
    }

    public override void Interact()
    {
        dcManager.Reactivate();
    }
}
