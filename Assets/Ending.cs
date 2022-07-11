using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip doorBellClip;
    [SerializeField] EndingDoorInteraction endingDoorInteraction;

    float timeUntilRingingStarts = 7f; 
    float TimeElapsed;

    bool isRingning  =  false;

    void Start()
    {
        Messenger.AddListener("LastInteraction", KillThis);
        TimeElapsed = timeUntilRingingStarts;
    }

    private void Update()
    {
        TimeElapsed -= Time.deltaTime;

        if(TimeElapsed <= 0 && isRingning  ==  false)
        {
            isRingning = true;
            audioSource.clip = doorBellClip;
            audioSource.loop = true;
            audioSource.Play();
            endingDoorInteraction.enabled = true;
        }
    }

    void KillThis()
    {
        audioSource.enabled = false;
    }
}
