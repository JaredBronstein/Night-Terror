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
    private Slider GeneratorPressureDial;

    [SerializeField]
    private int stabilitySize, resetDelay;

    [SerializeField]
    private float maxTime;

    private MovementController movementController;
    private int minValue, maxValue;
    private float currentTime;
    private bool isUIActive = false, isGeneratorActive = true;

    /// <summary>
    /// Sets time to max, grabs Slider and Movement controller, then disables the Ui and resets the new correct slider position
    /// </summary>
    private void Awake()
    {
        currentTime = maxTime;
        movementController = FindObjectOfType<MovementController>();
        GeneratorPressureDial = FindObjectOfType<Slider>();
        DisableUI(true);
        ResetPosition();
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
        if(Input.GetButtonDown("Cancel") && isUIActive)
        {
            DisableUI(false);
        }
    }

    /// <summary>
    /// Delay so that it waits before reseting the correct slider position
    /// </summary>
    private IEnumerator ResetPositionDelay()
    {
        yield return new WaitForSeconds(resetDelay);
        ResetPosition();
    }
    
    /// <summary>
    /// Resets the slider position so it isn't where the slider currently is
    /// </summary>
    private void ResetPosition()
    {
        do
        {
            minValue = (int)Random.Range(GeneratorPressureDial.minValue, GeneratorPressureDial.maxValue - stabilitySize);
            maxValue = minValue + stabilitySize;
        }while (GeneratorPressureDial.value < maxValue && GeneratorPressureDial.value > minValue) ;
        Debug.Log("Generator Range is " + minValue + ", " + maxValue);
    }

    private void DisableUI(bool isFirst)
    {
        isUIActive = false;
        movementController.setCanMove(true);
        GeneratorPressureDial.gameObject.transform.localScale = new Vector3(0, 0, 0);
        if(!isFirst)
            StartCoroutine(ResetPositionDelay());
    }

    public void EnableUI()
    {
        StopCoroutine(ResetPositionDelay());
        isUIActive = true;
        movementController.setCanMove(false);
        GeneratorPressureDial.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    /// <summary>
    /// Called by the Slider whenever it's moved. If it's in the correct zone, restore power to max
    /// </summary>
    public void SliderChange()
    {
        if (isUIActive && GeneratorPressureDial.value >= minValue && GeneratorPressureDial.value <= maxValue)
        {
            Debug.Log("Generator has been restored!");
            currentTime = maxTime;
        }
    }

    public bool getIsGeneratorActive()
    {
        return isGeneratorActive;
    }
}
