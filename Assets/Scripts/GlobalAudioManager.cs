using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource owlSound, wolfSound, bearSound, BirdSound, owlSoundF, wolfSoundF, bearSoundF, BirdSoundF;

    [SerializeField]
    private float minDelay = 3, maxDelayIdle = 5, maxDelayHunt = 2;

    private Skinwalker skinwalker;

    private void Awake()
    {
        skinwalker = FindObjectOfType<Skinwalker>();
        StartCoroutine(playAudio());
    }

    private IEnumerator playAudio()
    {
        while(true)
        {
            if(skinwalker.getHuntedRoom() == null)
                yield return new WaitForSeconds(minDelay + Random.Range(0, maxDelayIdle));
            else
                yield return new WaitForSeconds(minDelay + Random.Range(0, maxDelayHunt));
            if(Random.Range(0, 1) == 1)
            {
                int choice = Random.Range(0, 1);
                switch (choice)
                {
                    case 0:
                        if (skinwalker.getHuntedRoom().GetStateOne() == RoomType.StateOne.Owl)
                            owlSoundF.Play();
                        else
                            wolfSoundF.Play();
                        break;
                    case 1:
                        if (skinwalker.getHuntedRoom().GetStateTwo() == RoomType.StateTwo.Bear)
                            bearSoundF.Play();
                        else
                            BirdSoundF.Play();
                        break;
                }
            }
            else
            {
                int choice = Random.Range(0, 1);
                switch(choice)
                {
                    case 0:
                        if (skinwalker.getHuntedRoom().GetStateOne() == RoomType.StateOne.Owl)
                            owlSound.Play();
                        else
                            wolfSound.Play();
                        break;
                    case 1:
                        if (skinwalker.getHuntedRoom().GetStateTwo() == RoomType.StateTwo.Bear)
                            bearSound.Play();
                        else
                            BirdSound.Play();
                        break;
                }
            }
        }
    }
}
