using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCue : MonoBehaviour
{
    [SerializeField]
    private Room[] audioAdjacentRooms;

    private AudioSource audioCue;
    private MovementController movementController;
    private Room PlayerRoom, ActiveRoom;

    private void Awake()
    {
        audioCue = GetComponent<AudioSource>();
        movementController = FindObjectOfType<MovementController>();
    }

    private void Update()
    {
        PlayerRoom = movementController.getCurrentRoom();
        if (ActiveRoom != null)
        {
            if(ActiveRoom == PlayerRoom)
            {
                audioCue.volume = 1.0f;
            }
            else if(isAdjacent(PlayerRoom))
            {
                audioCue.volume = 0.5f;
            }
            else
            {
                audioCue.volume = 0;
            }
        }
    }

    public void activeState(bool isActive, Room huntedRoom)
    {
        ActiveRoom = huntedRoom;
        if (isActive && PlayerRoom == huntedRoom || isActive && isAdjacent(PlayerRoom))
        {
            audioCue.Play();
        }
        else
        {
            audioCue.Stop();
            ActiveRoom = null;
        }

    }

    private bool isAdjacent(Room currentRoom)
    {
        foreach(Room room in audioAdjacentRooms)
        {
            if(room == currentRoom)
            {
                return true;
            }
        }
        return false;
    }
}
