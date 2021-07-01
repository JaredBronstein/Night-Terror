using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamCatcherRoom : Room
{
    private Skinwalker skinwalker;
    private DCManager dcManager;

    protected override void Awake()
    {
        base.Awake();
        skinwalker = FindObjectOfType<Skinwalker>();
        dcManager = FindObjectOfType<DCManager>();
    }

    protected override void Update()
    {

    }

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
