using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPosition;

    [SerializeField]
    private string name;

    [Tooltip("Group of Adjacent Rooms, goes Left, Right, Forward, Back")]
    [SerializeField]
    private Room[] adjacentRooms = new Room[4];

    public Transform getCameraPosition()
    {
        return cameraPosition;
    }

    public Room[] getAdjacent()
    {
        return adjacentRooms;
    }

    public string getName()
    {
        return name;
    }
}
