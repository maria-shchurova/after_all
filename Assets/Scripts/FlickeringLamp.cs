using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class FlickeringLamp : MonoBehaviour
{
    AudioSource audiosource;
    AudioClip explosion;

    Animator animator;
    HDAdditionalLightData LightData;
    Light light;

    public float newHightLightIntensity;
    public float newLowLightIntensity;

    public float newWiderLightAngleWidth;
    public float newNarrowerLightAngleWidth;
    void Start()
    {
        Messenger.AddListener("GetLighter", GetLighter);
        Messenger.AddListener("GetDarker", GetDarker);

        animator = GetComponent<Animator>();
        //audiosource = GetComponent<AudioSource>();
        LightData = GetComponentInChildren<HDAdditionalLightData>();
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void GetLighter()
    {
        animator.SetTrigger("GetBright");
    }

    void GetDarker()
    {
        animator.SetTrigger("GetDark");
    }
}
