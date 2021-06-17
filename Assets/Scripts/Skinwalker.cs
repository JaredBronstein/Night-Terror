using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skinwalker : MonoBehaviour
{
    [SerializeField]
    private float idleTime = 5.0f, huntTime, damagePerSecond, audioDelay;


    private enum SkinwalkerState {Idle, Search, Hunt};
    private SkinwalkerState skinwalkerState = SkinwalkerState.Idle;

    private Room[] Rooms;
    private List<Room> MarkedRooms = new List<Room>();
    private Room target;

    private void Awake()
    {
        Rooms = FindObjectsOfType<Room>();
        int roomNbr = 0, size = Random.Range(0, Rooms.Length);
        foreach(Room room in Rooms)
        {
            if(room.getIsMarked())
            {
                MarkedRooms.Add(room);
                if(roomNbr == size)
                {
                    MarkedRooms.Add(room);
                    MarkedRooms.Add(room);
                    Debug.Log("Favorite Room: " + room.getName());
                }
                roomNbr++;
            }
        }
        StartCoroutine(Idle());
    }
    //Must modify, prevent the Coroutine from being started multiple times due to being in Update. Maybe have Idle called once and then lead into later methods?
    private void Update()
    {
         if (skinwalkerState == SkinwalkerState.Hunt)
        {
            //Currently, shouldn't do anything, but in the future should be linked to playing audio effects based on chosen room
            if(target == null)
            {
                Debug.Log("No target to use!");
            }
            else
            {
                if(target.getHasIncense() == true)
                {
                    StopCoroutine(RoomTimeout());
                    Reset();
                }
            }
        }
    }

    private IEnumerator Idle()
    {
        yield return new WaitForSeconds(idleTime);
        skinwalkerState = SkinwalkerState.Search;
        Search();
    }

    private void Search()
    {
        int choice = Random.Range(0, MarkedRooms.Count);
        target = MarkedRooms[choice];
        target.setIsHunted(true);
        skinwalkerState = SkinwalkerState.Hunt;
        Hunt();
    }

    private void Hunt()
    {
        StartCoroutine(RoomTimeout());
    }

    private IEnumerator RoomTimeout()
    {
        yield return new WaitForSeconds(huntTime);
        Reset();
    }

    private void Reset()
    {
        target.setIsHunted(false);
        skinwalkerState = SkinwalkerState.Idle;
        StartCoroutine(Idle());
    }

    /// <summary>
    /// Used to add the fireplace when mechanic is added
    /// </summary>
    public void AddRoom()
    {

    }
}
