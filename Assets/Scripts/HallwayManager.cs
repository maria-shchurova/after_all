using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    [SerializeField] GameObject RedHornsGrowth;
    [SerializeField] GameObject HairGrowth;
    [SerializeField] GameObject Staircase;
    [SerializeField] GameObject StaircasePanel;
    [SerializeField] GameObject FishEyeCam;
    [SerializeField] GameObject FishEyeVol;
    [SerializeField] GameObject MainCamera;

    [SerializeField] GameObject Floor;
    [SerializeField] Material Material;

   

    [SerializeField] AudioClip doorKnocking;
    [SerializeField] AudioSource Knocking;

    float Duration = 2f; // for carpet
    float TimeElapsed;


    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener("RedHorns", RedHorns);
        Messenger.AddListener("Hair", Hair);

        Messenger.AddListener("Knocking2", Door);
        Messenger.AddListener("Staircase", Stairs);


        Messenger.AddListener("LastInteraction", StairsForEnding);
    }

    void Update()
    {
        TimeElapsed -= Time.deltaTime;
        if(TimeElapsed<=0 && Staircase.activeSelf)
        {
            Floor.GetComponent<MeshRenderer>().material = Material;
        }
    }

    void RedHorns()
    {
        RedHornsGrowth.SetActive(true);
    }

    void Hair()
    {
        HairGrowth.SetActive(true);
    }

    void Door()
    {
        Knocking.clip = doorKnocking;
        Knocking.Play();
    }

    void Stairs()
    {
        StaircasePanel.SetActive(true);
        FishEyeCam.SetActive(true);
        MainCamera.SetActive(false);
        FishEyeVol.SetActive(true);
        TimeElapsed = Duration;
        Staircase.SetActive(true);
    }

    void StairsForEnding()
    {
        FishEyeCam.SetActive(true);
        MainCamera.SetActive(false);
        FishEyeVol.SetActive(true);
        Staircase.SetActive(true);
    }
}
