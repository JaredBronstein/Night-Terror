using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Used by the Main Menu to determine what presets the Skinwalker should start on based on the night selected
/// </summary>
public class NightManager : MonoBehaviour
{
    public void NightOne()
    {
        Skinwalker.setPresets(3.0f, 3.0f, 3.0f, 0.0f);
        SceneSwap();
    }
    public void NightTwo()
    {
        Skinwalker.setPresets(6.0f, 1.0f, 5.0f, 0.0f);
        SceneSwap();
    }
    public void NightThree()
    {
        Skinwalker.setPresets(1.0f, 15.0f, 1.0f, 0.0f);
        SceneSwap();
    }
    public void NightFour()
    {
        Skinwalker.setPresets(30.0f, 15.0f, 15.0f, 0.0f);
        SceneSwap();
    }
    public void NightFive()
    {
        Skinwalker.setPresets(1.0f, 1.0f, 1.0f, 1.0f);
        SceneSwap();
    }

    private void SceneSwap()
    {
        SceneManager.LoadScene("Cabin");
    }
}
