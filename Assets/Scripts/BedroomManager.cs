using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomManager : MonoBehaviour
{
    [SerializeField] GameObject BassGuitar;
    [SerializeField] GameObject BrokenBassGuitar;
    void Start()
    {
        Messenger.AddListener("breakBass", BreakBass);
    }

    // Update is called once per frame
    void BreakBass()
    {
        BassGuitar.SetActive(false);
        BrokenBassGuitar.SetActive(true);
    }
}
