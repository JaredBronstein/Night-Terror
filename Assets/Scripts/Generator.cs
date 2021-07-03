using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactive Object to enable Generator UI for minigame
/// </summary>
public class Generator : MonoBehaviour
{
    private GManager gManager;
    private bool isBeingPowered = false;

    private void Awake()
    {
        gManager = FindObjectOfType<GManager>();
    }

    public void setIsBeingPowered()
    {

    }
}
