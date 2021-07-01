using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncenseManager : MonoBehaviour
{
    private int IncenseUses = 1;

    private MovementController movementController;

    private void Awake()
    {
        movementController = FindObjectOfType<MovementController>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            UseIncense();
        }
    }

    /// <summary>
    /// Grabs the current room, checks if it's marked and then if it has the incense already, take it, if it doesn't remove it
    /// from inventory, and if there is no incense in the inventory, say you can't. If it's not marked, say it can't be used
    /// </summary>
    private void UseIncense()
    {
        Room CurrentRoom = movementController.getCurrentRoom();
        if(CurrentRoom.getIsMarked())
        {
            if(CurrentRoom.getHasIncense())
            {
                IncenseUses++;
                CurrentRoom.setHasIncense(false);
                Debug.Log(CurrentRoom.name + " now longer has incense burning.");
            }
            else if(IncenseUses > 0)
            {
                IncenseUses--;
                CurrentRoom.setHasIncense(true);
                Debug.Log(CurrentRoom.name + " now has incense burning.");
            }
            else if(IncenseUses == 0 && !CurrentRoom.getHasIncense())
            {
                Debug.Log("You are out of incense to burn");
            }
        }
        else
        {
            Debug.Log("This room cannot burn incense");
        }
    }
}
