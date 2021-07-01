using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all interactive objects. Meant to be overridden
/// </summary>
public class InteractiveObject : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log(name + " has been interacted with.");
    }
}
