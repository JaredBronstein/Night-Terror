using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPosition;

    [SerializeField]
    private GameObject incenseSprite = null;

    [SerializeField]
    private string name;

    [Tooltip("Group of Adjacent Rooms, goes Left, Right, Forward, Back")]
    [SerializeField]
    private Room[] adjacentRooms = new Room[4];

    [SerializeField]
    private bool isMarked;

    private bool HasIncense = false;
    private bool IsHunted = false;

    private void Awake()
    {
        if(incenseSprite != null)
        {
            incenseSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

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

    public bool getIsMarked()
    {
        return isMarked;
    }

    public bool getHasIncense()
    {
        return HasIncense;
    }

    public void setHasIncense(bool newValue)
    {
        HasIncense = newValue;
        if(HasIncense)
        {
            incenseSprite.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            incenseSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void setIsHunted(bool newValue)
    {
        IsHunted = newValue;
        Debug.Log(name + " has had it's IsHunted value change to " + newValue);
    }
}
