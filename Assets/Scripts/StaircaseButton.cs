using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseButton : MonoBehaviour
{
    [SerializeField] GameObject FishEyeCam;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject FishEyeVol;
    [SerializeField] GameObject StaircasePanel;
    [SerializeField] GameObject Staircase;

    public void Back()
    {
        FishEyeCam.SetActive(false);
        MainCamera.SetActive(true);
        FishEyeVol.SetActive(false);
        StaircasePanel.SetActive(false);
        Staircase.SetActive(false);
    }
}
