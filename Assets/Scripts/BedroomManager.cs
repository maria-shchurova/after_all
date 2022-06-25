using System;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine;

public class BedroomManager : MonoBehaviour
{
    [SerializeField] GameObject bassGuitar;
    [SerializeField] GameObject bassBroken;

    [SerializeField] GameObject Butterflies;
    [SerializeField] GameObject Spider;
    [SerializeField] GameObject Elephant;

    [SerializeField] GameObject GoodPoster;
    [SerializeField] GameObject BadPoster;
    [SerializeField] GameObject DefaultBand;
    [SerializeField] GameObject GoodPosterPanel;
    [SerializeField] GameObject BadPosterPanel;
    [SerializeField] GameObject DefaultBandPanel;


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
        Messenger.AddListener("Elephant", ElephantOn);

        Messenger.AddListener("Butterflies", ButterfliesOn);
        Messenger.AddListener("Spider", SpiderOn);

        Messenger.AddListener("GoodPoster", GoodPosterOn);
        Messenger.AddListener("BadPoster", BadPosterOn);
    }

    private void ElephantOn()
    {
        Elephant.SetActive(true);
    }

    private void SpiderOn()
    {
        Spider.SetActive(true);
    }

    private void ButterfliesOn()
    {
        Butterflies.SetActive(true);
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

    private void GoodPosterOn()
    {
        GoodPosterPanel.SetActive(true);
        Invoke("SetFalse", 5.0f); // this should call SetFalse function after 5 seconds

        DefaultBand.SetActive(false); // this should deactivate the original object
        GoodPoster.SetActive(true); //this makes goodposter active // how can I open the canvas?
    }

    private void BadPosterOn()
    {
        BadPosterPanel.SetActive(true);
        Invoke("SetFalse", 5.0f);
        DefaultBand.SetActive(false);
        BadPoster.SetActive(true);
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

    void SetFalse()
    {
        GoodPosterPanel.SetActive(false);
        BadPosterPanel.SetActive(false);
    }
}
