using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : InteractiveObject
{
    [SerializeField]
    private float maxTime = 45;

    [SerializeField]
    private Room fireplace;

    private Skinwalker skinwalker;
    private float currentTime;
    private bool hasFuel = false;

    private void Awake()
    {
        skinwalker = FindObjectOfType<Skinwalker>();
        currentTime = maxTime;
        StartCoroutine(fuelTime());
    }

    /// <summary>
    /// Constantly ticks down the fuel time. Can't be a void method since it doesn't actually wait.
    /// When time is up, fire goes out, and the fireplace is added to the Skinwalker's list
    /// </summary>
    private IEnumerator fuelTime()
    {
        while(currentTime > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currentTime--;
        }
        Debug.Log("Fire is out");
        fireplace.setIsMarked(true);
        skinwalker.AddRoom(fireplace, 3);
    }

    /// <summary>
    /// Overrides the interact function to add fuel, state the fire's out and thus cannot relight, or state you
    /// have no fuel
    /// </summary>
    public override void Interact()
    {
        if(hasFuel && currentTime > 0)
        {
            Debug.Log("More fuel for the fire");
            hasFuel = false;
            currentTime = maxTime;
        }
        else if(currentTime <= 0)
        {
            Debug.Log("Fire's out, you cannot relight it.");
        }
        else
        {
            Debug.Log("You don't have any fuel");
        }
    }

    /// <summary>
    /// Used by the woodpile InteractiveObject class so the HasFuel bool stays in just the fireplace class
    /// </summary>
    public void addFuel()
    {
        hasFuel = true;
    }
}
