using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    [SerializeField] AudioClip ClothDrop;
    [SerializeField] AudioClip Intro1;
    [SerializeField] AudioClip Intro2;
    [SerializeField] AudioClip Key1;
    [SerializeField] AudioClip Key2;

    AudioSource myAudio;
    

    void Start()
    {
        Messenger.AddListener("ClothDrop", Drop);
        Messenger.AddListener("Key1", Key);
        Messenger.AddListener("Key2", KeyDrop);
        Messenger.AddListener("Intro1",Open);
        Messenger.AddListener("Intro2", Slamming);
        Messenger.AddListener("Finish", GetRid);

        myAudio = GetComponent<AudioSource>();

        //Invoke("Key", 44f);
        //Invoke("Open", 48f);
        //Invoke("KeyDrop", 53f);
        //Invoke("Slamming", 55f);
    }

    private void Drop()
    {
        myAudio.clip = ClothDrop;
        myAudio.Play();
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

    void Key()
    {
        myAudio.clip = Key1;
        myAudio.Play();
    }

    void KeyDrop()
    {
        myAudio.clip = Key2;
        myAudio.Play();
    }

    void GetRid()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))  //skip
        {
            GetRid();
        }
    }

}
