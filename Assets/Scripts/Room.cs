using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Primary Room class used by most classes to function
/// </summary>
public class Room : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The position the camera is in to see the room")]
    private Transform cameraPosition;

    [SerializeField]
    private GameObject incenseSprite = null;

    [SerializeField]
    private string name;

    [SerializeField]
    [Tooltip("Group of Adjacent Rooms, goes Left, Right, Forward, Back")]
    private Room[] adjacentRooms = new Room[4];

    [SerializeField]
    private bool isMarked;

    [SerializeField]
    private float roomHealth = 100;

    private bool HasIncense = false;
    protected bool IsHunted = false;

    /// <summary>
    /// Disables the Incense Sprite
    /// </summary>
    protected virtual void Awake()
    {
        if(incenseSprite != null)
        {
            incenseSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    /// <summary>
    /// Checks if it's health is at or below zero for a game over or if it needs to lose health for being hunted
    /// </summary>
    protected virtual void Update()
    { 
        if(roomHealth <= 0)
        {
            Debug.Log(name + " has been breached, game over!");
            SceneManager.LoadScene("MainMenu");
        }
        else if(IsHunted)
        {
            roomHealth -= Skinwalker.getDamagePerSecond() * Time.deltaTime;
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

    public void setIsMarked(bool IsMarked)
    {
        isMarked = IsMarked;
    }

    public bool getHasIncense()
    {
        return HasIncense;
    }

    /// <summary>
    /// Used when the player takes or places down incense in this room
    /// </summary>
    /// <param name="newValue">Whether the Incense Manager has determined it's giving or taking incense</param>
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

    public bool getIsHunted()
    {
        return IsHunted;
    }

    /// <summary>
    /// Used by the Skinwalker Class to target or de-target rooms.
    /// </summary>
    public virtual void setIsHunted(bool newValue)
    {
        IsHunted = newValue;
        if (newValue)
            Debug.Log(name + " has been targeted.");
        else
        {
            roomHealth = Mathf.Round(roomHealth * 100) / 100;
            Debug.Log(name + " is now safe, but it's HP is at " + roomHealth);
        }
    }
}
