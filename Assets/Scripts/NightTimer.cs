using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightTimer : MonoBehaviour
{
    [SerializeField]
    private int nightDuration = 180;

    private void Awake()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        while(nightDuration > 0)
        {
            yield return new WaitForSeconds(1.0f);
            nightDuration -= 1;
        }
        Debug.Log("You survived the night!");
        SceneManager.LoadScene("MainMenu");
    }
}
