using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interactive object in the living room that will lead to the Fireplace "Room"
/// </summary>
public class FireplaceAccess : InteractiveObject
{
    [SerializeField]
    private Room fireplace;

    private MovementController movementController;

    private void Awake()
    {
        movementController = FindObjectOfType<MovementController>();
    }

    public override void Interact()
    {
        movementController.Move(fireplace);
    }
}
