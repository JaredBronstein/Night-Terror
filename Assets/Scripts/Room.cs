using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private float roomHealth = 100;

    private bool HasIncense = false;
    private bool IsHunted = false;

    private void Awake()
    {
        if(incenseSprite != null)
        {
            incenseSprite.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void Update()
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
        if (newValue)
            Debug.Log(name + " has been targeted.");
        else
        {
            roomHealth = Mathf.Round(roomHealth * 100) / 100;
            Debug.Log(name + " is now safe, but it's HP is at " + roomHealth);
        }

    }
}
