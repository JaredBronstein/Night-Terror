using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : InteractiveObject
{
    private GManager gManager;

    private void Awake()
    {
        gManager = FindObjectOfType<GManager>();
    }

    public override void Interact()
    {
        base.Interact();
        gManager.EnableUI();
    }
}
