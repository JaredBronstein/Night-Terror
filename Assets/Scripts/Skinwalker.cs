using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Primary class in handling the Skinwalker AI
/// </summary>
public class Skinwalker : MonoBehaviour
{
    private static float idleTime = 3.0f, huntTime = 3.0f, damagePerSecond = 3.0f, damageMultiplier = 1.0f, audioDelay;

    [SerializeField]
    [Tooltip("The range in which the Skinwalker will stray from the time set by IdleTime and HuntTime")]
    private float variableRange = 1.5f;

    /// <summary>
    /// Mainly used to keep track of itself
    /// </summary>
    private enum SkinwalkerState {Idle, Search, Hunt};
    private SkinwalkerState skinwalkerState = SkinwalkerState.Idle;

    private Room[] Rooms;
    private List<Room> MarkedRooms = new List<Room>();
    private Room target;

    /// <summary>
    /// Logs static values, then grabs all rooms, adds all marked rooms into a List, then selects a favorite and moves
    /// to an idle state
    /// </summary>
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
    /// <summary>
    /// Used mainly for audio in the future, failsafe if there's no target, and stops hunting in a room if the incense is
    /// being burned there
    /// </summary>
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
                    StopCoroutine(Hunt());
                    Reset();
                }
            }
        }
    }

    /// <summary>
    /// Waits, then starts searching for a room
    /// </summary>
    private IEnumerator Idle()
    {
        yield return new WaitForSeconds(idleTime + Random.Range(-variableRange, variableRange));
        skinwalkerState = SkinwalkerState.Search;
        Search();
    }

    /// <summary>
    /// Randomly selects a room from the list, and starts hunting it. If it's the dreamcatcher room, immediately reset to idle
    /// </summary>
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
            StartCoroutine(Hunt());
        }
    }

    /// <summary>
    /// Stays at location for hunt time give or take variableRange, then reset to idle
    /// </summary>
    private IEnumerator Hunt()
    {
        yield return new WaitForSeconds(huntTime + Random.Range(-variableRange, variableRange));
        Reset();
    }

    /// <summary>
    /// Resets the Skinwalker back to an idle state
    /// </summary>
    public void Reset()
    {
        target.setIsHunted(false);
        skinwalkerState = SkinwalkerState.Idle;
        StartCoroutine(Idle());
    }

    /// <summary>
    /// Used to add rooms to the List and in specified quantities to increase odds
    /// </summary>
    public void AddRoom(Room roomtoAdd, int numberOfAdditions)
    {
        for(int i = 0; i < numberOfAdditions; i++)
        {
            MarkedRooms.Add(roomtoAdd);
        }
    }

    /// <summary>
    /// Sent to rooms to know how much damage they're taking a second
    /// </summary>
    /// <returns></returns>
    public static float getDamagePerSecond()
    {
        return damagePerSecond * damageMultiplier;
    }

    /// <summary>
    /// Called by level starting buttons to adjust the Skinwalker's presets when the scene changes to the Cabin
    /// </summary>
    public static void setPresets(float IdleTime, float HuntTime, float DamagePerSecond, float AudioDelay)
    {
        idleTime = IdleTime;
        huntTime = HuntTime;
        damagePerSecond = DamagePerSecond;
        audioDelay = AudioDelay;
    }

    /// <summary>
    /// Used by the Dreamcatcher Manager to change the multiplier based on whether it's up or down
    /// </summary>
    public static void setMultiplier(float multiplier)
    {
        damageMultiplier = multiplier;
    }
}
