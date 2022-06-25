using System;
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
    [SerializeField] Material NewShirtMaterial;
    [SerializeField] GameObject[] Wings;
    [SerializeField] SkinnedMeshRenderer CharacterRenderer;
    void Start()
    {
        Messenger.AddListener("MirrorCrack", MirrorCrack);
        Messenger.AddListener("Smile", Smile);
        Messenger.AddListener("Whale", BathtubBad);
        Messenger.AddListener("BubblyBath", HappyBath);
        Messenger.AddListener("Change shirt", Change);
        Messenger.AddListener("Wings", GrowWings);
        Messenger.AddListener("Storm", Storm);
    }

    private void Storm()
    {
        throw new NotImplementedException();
    }

    private void GrowWings()
    {
       foreach(GameObject wing  in Wings)
        {
            wing.SetActive(true);
        }
    }

    private void Change()
    {
        CharacterRenderer.material = NewShirtMaterial;
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
