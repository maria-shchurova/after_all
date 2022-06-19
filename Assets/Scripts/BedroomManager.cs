using System;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine;

public class BedroomManager : MonoBehaviour
{
    [SerializeField] GameObject bassGuitar;
    [SerializeField] GameObject bassBroken;

    [SerializeField] ReactToSound dancingLight;
    [SerializeField] AudioClip happyBassSound;
    [SerializeField] AudioClip breakingBassSound;
    [SerializeField] AudioSource Bass;

    [SerializeField] Volume m_Volume;
    void Start()
    {
        Messenger.AddListener("breakBass", BreakBass);
        Messenger.AddListener("playSound", HappyBass);

        Messenger.AddListener("Noise", NoiseOn);
    }

    private void NoiseOn()
    {
        FilmGrain grain;
        ChromaticAberration ChA;
        m_Volume.profile.TryGet(out grain);
        m_Volume.profile.TryGet(out ChA);

        grain.active = true;
        ChA.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void BreakBass()
    {
        bassGuitar.SetActive(false);
        bassBroken.SetActive(true);

        Bass.clip = breakingBassSound;
        Bass.Play();
    }

    void HappyBass()
    {
        dancingLight.enabled = true;
        Bass.clip = happyBassSound;
        Bass.Play();
    }
}
