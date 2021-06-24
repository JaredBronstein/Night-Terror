using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
