using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Attaches box collider to the mouse for the sake of interacting with non-button objects in the scene
/// </summary>
public class AttachToMouse : MonoBehaviour
{
    private Vector3 mousePosition;
    void Update()
    {
        this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
    }
}
