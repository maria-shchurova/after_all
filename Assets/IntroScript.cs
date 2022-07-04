using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    [SerializeField] AudioClip Intro1;
    [SerializeField] AudioClip Intro2;

    AudioSource myAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        
        Messenger.AddListener("Intro1",Open);
        Messenger.AddListener("Intro2", Slamming);

        myAudio = GetComponent<AudioSource>();

        Invoke("Open", 50f);
        Invoke("Slamming", 53f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open()
    {
        myAudio.clip = Intro1;
        myAudio.Play();
    }


    void Slamming()
    {
        myAudio.clip = Intro2;
        myAudio.Play();
    }

    void GetRid()
    {
        Destroy(gameObject, 65f);
    }

}
