  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;


public class Storm : MonoBehaviour
{
    public float repeatingInterval;
    public float strikeLendth;
    float timeElapsed;

    [SerializeField] float Duration;


    [SerializeField] Animator bathroomLight;

    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip thunder, rainBG;

    [SerializeField] GameObject Lighting;

    [SerializeField] HDAdditionalLightData[] allDirectionalLights;
    [SerializeField] GameObject[] warmLights;
    [SerializeField] GameObject coldGlobalLight;
    void Start()
    {
        if(MoodKeeper.MoodScale < 0)
        {
            Duration += 20;
        }
        else
        {
            Duration -= 20;
        }

        bathroomLight.enabled = true;
        timeElapsed = repeatingInterval;

        foreach(HDAdditionalLightData light in allDirectionalLights)
        {
            light.EnableShadows(false);  //because they  cannot  work in the same time together
        }        
        
        foreach(GameObject light in warmLights)
        {
            light.SetActive(false);  
        }

        coldGlobalLight.SetActive(true);
    }
    private void Update()
    {
        timeElapsed -= Time.deltaTime;
        if(timeElapsed <=  0)
        {
            Strike();
            timeElapsed = repeatingInterval;
        }

        if(audiosource.isPlaying == false)
        {
            audiosource.clip = rainBG;
            audiosource.loop = true;
            audiosource.Play();
        }

        if(Duration  <=  0)
        {
            audiosource.volume -= Time.deltaTime;
            Destroy(gameObject, 5);
        }
        else
        {
            Duration -= Time.deltaTime;
        }
    }
    void Strike()
    {
        audiosource.loop = true;
        audiosource.clip = thunder;
        Lighting.SetActive(true);
    }

}
