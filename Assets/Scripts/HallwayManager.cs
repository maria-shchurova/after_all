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

    //[SerializeField] GameObject Material1;
    //[SerializeField] GameObject Material2;

    [SerializeField] AudioClip doorKnocking;
    [SerializeField] AudioSource Knocking;


    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener("RedHorns", RedHorns);
        Messenger.AddListener("Hair", Hair);

        Messenger.AddListener("Knocking2", Door);
        Messenger.AddListener("Staircase", Stairs);
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
        Staircase.SetActive(true);
        StaircasePanel.SetActive(true);
        FishEyeCam.SetActive(true);
        MainCamera.SetActive(true);
        FishEyeVol.SetActive(true);
        //Material1 = Material2;
    }
}
