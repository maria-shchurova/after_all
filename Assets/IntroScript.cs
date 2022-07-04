using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    [SerializeField] AudioClip Intro1;
    [SerializeField] AudioClip Intro2;
    [SerializeField] AudioClip Key1;
    [SerializeField] AudioClip Key2;

    AudioSource myAudio;
    

    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener("Key1", Key);
        Messenger.AddListener("Key2", KeyDrop);
        Messenger.AddListener("Intro1",Open);
        Messenger.AddListener("Intro2", Slamming);

        myAudio = GetComponent<AudioSource>();

        Invoke("Key", 44f);
        Invoke("Open", 48f);
        Invoke("KeyDrop", 53f);
        Invoke("Slamming", 55f);
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
        Destroy(gameObject, 65f);
    }

}
