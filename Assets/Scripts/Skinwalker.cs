using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skinwalker : MonoBehaviour
{
    private static float idleTime = 3.0f, huntTime = 3.0f, damagePerSecond = 3.0f, damageMultiplier = 1.0f, audioDelay;

    [SerializeField]
    private float variableRange = 1.5f;

    private enum SkinwalkerState {Idle, Search, Hunt};
    private SkinwalkerState skinwalkerState = SkinwalkerState.Idle;

    private Room[] Rooms;
    private List<Room> MarkedRooms = new List<Room>();
    private Room target;

    private void Awake()
    {
        Debug.Log(idleTime + "," + huntTime + "," + damagePerSecond + "," + audioDelay);
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
        yield return new WaitForSeconds(idleTime + Random.Range(-variableRange, variableRange));
        skinwalkerState = SkinwalkerState.Search;
        Search();
    }

    private void Search()
    {
        int choice = Random.Range(0, MarkedRooms.Count);
        target = MarkedRooms[choice];
        target.setIsHunted(true);
        skinwalkerState = SkinwalkerState.Hunt;
        if(target is DreamCatcherRoom)
        {
            Reset();
        }
        else
        {
            Hunt();
        }
    }

    private void Hunt()
    {
        StartCoroutine(RoomTimeout());
    }

    private IEnumerator RoomTimeout()
    {
        yield return new WaitForSeconds(huntTime + Random.Range(-variableRange, variableRange));
        Reset();
    }

    public void Reset()
    {
        target.setIsHunted(false);
        skinwalkerState = SkinwalkerState.Idle;
        StartCoroutine(Idle());
    }

    /// <summary>
    /// Used to add the fireplace when mechanic is added
    /// </summary>
    public void AddRoom(Room roomtoAdd, int numberOfAdditions)
    {
        for(int i = 0; i < numberOfAdditions; i++)
        {
            MarkedRooms.Add(roomtoAdd);
        }
    }

    public static float getDamagePerSecond()
    {
        return damagePerSecond * damageMultiplier;
    }

    public static void setPresets(float IdleTime, float HuntTime, float DamagePerSecond, float AudioDelay)
    {
        idleTime = IdleTime;
        huntTime = HuntTime;
        damagePerSecond = DamagePerSecond;
        audioDelay = AudioDelay;
    }

    public static void setMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
    }
}
