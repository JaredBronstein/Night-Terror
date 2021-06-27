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
    private Slider GeneratorPosition;

    [SerializeField]
    private int stableSize, resetDelay;

    [SerializeField]
    private float maxTime;

    private MovementController movementController;
    private int minValue, maxValue;
    private float currentTime;
    private bool isUIActive = false, isGeneratorActive = true;

    private void Awake()
    {
        currentTime = maxTime;
        movementController = FindObjectOfType<MovementController>();
        GeneratorPosition = FindObjectOfType<Slider>();
        DisableUI(true);
        ResetPosition();
    }

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

    private IEnumerator ResetPositionDelay()
    {
        yield return new WaitForSeconds(resetDelay);
        ResetPosition();
    }
    
    private void ResetPosition()
    {
        do
        {
            minValue = (int)Random.Range(GeneratorPosition.minValue, GeneratorPosition.maxValue - stableSize);
            maxValue = minValue + stableSize;
        }while (GeneratorPosition.value < maxValue && GeneratorPosition.value > minValue) ;
        Debug.Log("Generator Range is " + minValue + ", " + maxValue);
    }

    private void DisableUI(bool isFirst)
    {
        isUIActive = false;
        movementController.setCanMove(true);
        GeneratorPosition.gameObject.transform.localScale = new Vector3(0, 0, 0);
        if(!isFirst)
            StartCoroutine(ResetPositionDelay());
    }

    public void EnableUI()
    {
        StopCoroutine(ResetPositionDelay());
        isUIActive = true;
        movementController.setCanMove(false);
        GeneratorPosition.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void SliderChange()
    {
        if (isUIActive && GeneratorPosition.value >= minValue && GeneratorPosition.value <= maxValue)
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
