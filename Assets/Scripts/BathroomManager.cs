using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomManager : MonoBehaviour
{
    [SerializeField] GameObject MirrorDecal;
    [SerializeField] GameObject MirrorSmileDecal;
    [SerializeField] GameObject BathtubBadDecal;
    [SerializeField] GameObject BathtubYellowLight;
    [SerializeField] GameObject BathHappyObject;
    void Start()
    {
        Messenger.AddListener("MirrorCrack", MirrorCrack);
        Messenger.AddListener("Smile", Smile);
        Messenger.AddListener("Whale", BathtubBad);
        Messenger.AddListener("BubblyBath", HappyBath);
    }

    void MirrorCrack()
    {
        MirrorDecal.SetActive(true);
    }
    void Smile()
    {
        MirrorSmileDecal.SetActive(true);
    }

    void BathtubBad()
    {
        BathtubBadDecal.SetActive(true);
        BathtubYellowLight.SetActive(false);
    }
    void HappyBath()
    {
        BathHappyObject.SetActive(true);
    }
}
