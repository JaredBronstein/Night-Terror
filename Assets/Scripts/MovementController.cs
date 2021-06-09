using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private Room currentRoom;

    [SerializeField]
    private GameObject camera;

    private Room[] adjacentRooms;

    private void Awake()
    {
        SetAdjacent();
    }

    private void SetAdjacent()
    {
        adjacentRooms = currentRoom.getAdjacent();
    }

    public void Move(int i)
    {
        if(adjacentRooms[i] != null)
        {
            currentRoom = adjacentRooms[i];
            SetAdjacent();
            camera.transform.position = currentRoom.getCameraPosition().position;
        }
        else
        {
            Debug.Log("There is no room in this direction");
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Left"))
        {
            Move(0);
        }
        else if (Input.GetButtonDown("Right"))
        {
            Move(1);
        }
        else if (Input.GetButtonDown("Up"))
        {
            Move(2);
        }
        else if (Input.GetButtonDown("Down"))
        {
            Move(3);
        }
    }
}
