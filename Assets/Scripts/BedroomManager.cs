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
    [SerializeField] GameObject Canon; //invisible sphere that breaks  the floor  by falling on  it //wow coool!
    [SerializeField] GameObject NormalFloor; //original floor
    [SerializeField] GameObject BrokenFloor; 



    [SerializeField] ReactToSound dancingLight;
    [SerializeField] AudioClip happyBassSound;
    [SerializeField] AudioClip breakingBassSound;
    [SerializeField] AudioSource Bass;

    [SerializeField] Volume m_Volume;

    Animator Animator;
    [SerializeField] Animator goodAnim;
    [SerializeField] Animator badAnim;

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

        Messenger.AddListener("FloorCrash", FloorCrash);
        Messenger.AddListener("MiniSea", MiniSea);

        Animator = GetComponent<Animator>();
    }

    private void MiniSea()
    {
        throw new NotImplementedException();
    }

    private void FloorCrash()
    {
        NormalFloor.GetComponent<MeshRenderer>().enabled = false;
        NormalFloor.SetActive(false);
        BrokenFloor.SetActive(true);
        Canon.SetActive(true);
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
        Animator.SetTrigger("GoodPosterAnim");
        Animator.Play("GoodPosterAnim"); //play animation
        Invoke("SetFalse", 5.0f); // this should call SetFalse function after 5 seconds

        //those are the posters on the wall / not canvas
        DefaultBand.SetActive(false); // this should deactivate the original object
        GoodPoster.SetActive(true); //this makes goodposter active 
    }

    private void BadPosterOn()
    {
        BadPosterPanel.SetActive(true);
        Animator.SetTrigger("BadPosterAnim");
        Animator.Play("BadPosterAnim"); //play animation
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
