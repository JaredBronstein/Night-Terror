using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Child of Room class to modify what happens when the Skinwalker targets it to simply disable the Dreamcatcher
/// </summary>
public class DreamCatcherRoom : Room
{
    private Skinwalker skinwalker;
    private DCManager dcManager;

    protected override void Awake()
    {
        skinwalker = FindObjectOfType<Skinwalker>();
        dcManager = FindObjectOfType<DCManager>();
    }

    /// <summary>
    /// Empty to override the health degradation system this room doesn't need
    /// </summary>
    protected override void Update()
    {

    }

    /// <summary>
    /// Calls the Dreamcatcher deactivation function in the Manager
    /// </summary>
    /// <param name="newValue">the new value for IsHunted</param>
    public override void setIsHunted(bool newValue)
    {
        IsHunted = newValue;
        if (newValue)
        {
            Debug.Log(name + " has been targeted.");
            dcManager.Deactivate();
        }
    }
}
