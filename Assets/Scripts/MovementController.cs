using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages player movement in it's entirety
/// </summary>
public class MovementController : MonoBehaviour
{
    //Set initially as starting room, gets overwritten from there
    [SerializeField]
    private Room currentRoom;

    [SerializeField]
    private GameObject camera;

    [SerializeField]
    private Animator cameraFadeAnimator;

    private InteractManager interactManager;
    private UIManager uiManager;
    private Room[] adjacentRooms;
    private bool CanMove = true;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        interactManager = FindObjectOfType<InteractManager>();
        SetAdjacent();
    }

    /// <summary>
    /// Sets adjacent rooms based on the current room and adjusts UI to reflect that
    /// </summary>
    private void SetAdjacent()
    {
        adjacentRooms = currentRoom.getAdjacent();
        uiManager.UIChange(getAdjacentNames());
    }

    /// <summary>
    /// Attempts to move to a different room regardless of being adjacent or not. Called by certain interactive
    /// objects as well as Update when the player inputs certain keys
    /// </summary>
    /// <param name="room">The Room to move to</param>
    public void Move(Room room)
    {
        if(room != null && CanMove)
        {
            StartCoroutine(CameraFade(room));
        }
        else
        {
            Debug.Log("There is no room in this direction");
        }
    }

    /// <summary>
    /// Disables interactivity, starts fade out animation, changes room, starts fade in animation, enables interactivity
    /// </summary>
    /// <param name="room">Room to move to passed from Move</param>
    /// <returns></returns>
    private IEnumerator CameraFade(Room room)
    {
        interactManager.setCanInteract(false);
        cameraFadeAnimator.SetBool("IsDark", true);
        yield return new WaitForSeconds(1.0f);
        currentRoom = room;
        SetAdjacent();
        camera.transform.position = currentRoom.getCameraPosition().position;
        cameraFadeAnimator.SetBool("IsDark", false);
        yield return new WaitForSeconds(0.7f);
        interactManager.setCanInteract(true);
    }

    /// <summary>
    /// Checks for player inputs for room moving
    /// </summary>
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

    /// <summary>
    /// Used by the UI to display adjacent room names
    /// </summary>
    /// <returns>Returns as a string of four characters split by commas. The UI Manager splits it from there</returns>
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
