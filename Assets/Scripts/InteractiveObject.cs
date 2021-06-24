using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log(name + " has been interacted with.");
    }
}
