using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomManager : MonoBehaviour
{
    [SerializeField] GameObject MirrorDecal;
    [SerializeField] GameObject MirrorSmileDecal;
    [SerializeField] GameObject BathtubBadDecal;
    void Start()
    {
        Messenger.AddListener("MirrorCrack", MirrorCrack);
        Messenger.AddListener("Smile", Smile);
        Messenger.AddListener("Whale", BathtubBad);
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
    }
}
