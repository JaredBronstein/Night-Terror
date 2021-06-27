using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private Room currentRoom;

    [SerializeField]
    private GameObject camera;

    private UIManager uiManager;
    private Room[] adjacentRooms;
    private bool CanMove = true;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        SetAdjacent();
    }

    private void SetAdjacent()
    {
        adjacentRooms = currentRoom.getAdjacent();
        uiManager.UIChange(getAdjacentNames());
    }

    public void Move(Room room)
    {
        if(room != null && CanMove)
        {
            currentRoom = room;
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
        if(Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") == -1)
        {
            Move(adjacentRooms[0]);
        }
        else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") == 1)
        {
            Move(adjacentRooms[1]);
        }
        else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") == 1)
        {
            Move(adjacentRooms[2]);
        }
        else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") == -1)
        {
            Move(adjacentRooms[3]);
        }
    }

    public string getAdjacentNames()
    {
        string Left = "", Right = "", Forward = "", Back = "";
        if(adjacentRooms[0] != null)
        {
            Left = adjacentRooms[0].getName();
        }
        if (adjacentRooms[1] != null)
        {
            Right = adjacentRooms[1].getName();
        }
        if (adjacentRooms[2] != null)
        {
            Forward = adjacentRooms[2].getName();
        }
        if (adjacentRooms[3] != null)
        {
            Back = adjacentRooms[3].getName();
        }
        return Left + "," + Right + "," + Forward + "," + Back;
    }

    public Room getCurrentRoom()
    {
        return currentRoom;
    }

    public void setCanMove(bool newValue)
    {
        CanMove = newValue;
    }
}
