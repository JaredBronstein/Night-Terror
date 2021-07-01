using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactive Object to enable Generator UI for minigame
/// </summary>
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
