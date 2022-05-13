using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FlickeringLamp : MonoBehaviour
{
    AudioSource audiosource;
    AudioClip explosion;

    Animator animator;
    void Start()
    {
        Messenger.AddListener("GetLighter", GetLighter);
        Messenger.AddListener("Explode", Explode);

        animator = GetComponentInParent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void GetLighter()
    {
        animator.SetTrigger("GetBrighter");
    }

    void Explode()
    {
        audiosource.clip = explosion;
        animator.SetTrigger("Explode");
    }
}
