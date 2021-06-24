using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
