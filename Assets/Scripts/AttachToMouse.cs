using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToMouse : MonoBehaviour
{
    private Vector3 mousePosition;
    void Update()
    {
        this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0, 0, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
    }
}
