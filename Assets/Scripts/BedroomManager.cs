using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomManager : MonoBehaviour
{
    [SerializeField] GameObject bassGuitar;
    [SerializeField] GameObject bassBroken;

    [SerializeField] AudioClip happyBassSound;
    [SerializeField] AudioClip breakingBassSound;
    void Start()
    {
        Messenger.AddListener("breakBass", BreakBass);
        Messenger.AddListener("playSound", HappyBass);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BreakBass()
    {
        bassGuitar.SetActive(false);
        bassBroken.SetActive(true);
        AudioSource.PlayClipAtPoint(breakingBassSound, bassGuitar.transform.position);
    }

    void HappyBass()
    {
        AudioSource.PlayClipAtPoint(happyBassSound, bassGuitar.transform.position);
    }
}
