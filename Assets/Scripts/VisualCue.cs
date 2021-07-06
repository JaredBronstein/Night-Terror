using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Must be attached to a child of the Room object that triggers the visual cues, not the room where the cues are in
/// </summary>
public class VisualCue : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer cueObject;

    [SerializeField]
    private bool needsPower = false;

    private bool hasPower = true;
    private GManager gManager;
    private void Awake()
    {
        gManager = FindObjectOfType<GManager>();
        hasPower = gManager.getIsGeneratorActive();
        cueObject.enabled = false;
    }

    private void Update()
    {
        if(needsPower && !hasPower)
        {
            cueObject.enabled = false;
        }
    }

    public void activeState(bool isHunted)
    {
        if(!needsPower)
            cueObject.enabled = isHunted;
        else if(needsPower && hasPower)
            cueObject.enabled = isHunted;
    }
}
