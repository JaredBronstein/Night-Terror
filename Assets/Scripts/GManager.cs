using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the Generator System
/// </summary>
public class GManager : MonoBehaviour
{ 
    [SerializeField]
    private float maxTime, powerGain;

    private float currentTime;
    private bool isGeneratorActive = true;

    /// <summary>
    /// Sets time to max, grabs Slider and Movement controller, then disables the Ui and resets the new correct slider position
    /// </summary>
    private void Awake()
    {
        currentTime = maxTime;
    }

    /// <summary>
    /// Ticks down the generator clock and will disable the UI if it's active and the player cancels
    /// </summary>
    private void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Generator has been disabled.");
            isGeneratorActive = false;
        }   
    }

    public void PowerUp()
    {
        if(currentTime < maxTime)
        {
            currentTime += (Time.deltaTime + powerGain);
        }
        Debug.Log("Power is now " + currentTime + " out of " + maxTime);
    }

    public bool getIsGeneratorActive()
    {
        return isGeneratorActive;
    }
}
