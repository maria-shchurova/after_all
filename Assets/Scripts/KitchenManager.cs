using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    [SerializeField] GameObject dirtyDishes;
    [SerializeField] GameObject dishes;

    [SerializeField] GameObject FlowerInPlant;
    [SerializeField] GameObject PlantOriginal;
    [SerializeField] GameObject DeadPlant;
    [SerializeField] GameObject FridgeStickers;
    [SerializeField] GameObject FridgePuddle;

    [SerializeField] Volume m_Volume;
    void Start()
    {
        Messenger.AddListener("CleanDishes", CleanDishes);
        Messenger.AddListener("DirtyDishes", DirtyDishes);

        Messenger.AddListener("FlowerInPlant", PlantBlossom); 
        Messenger.AddListener("DeadPlant", PlantDies);

        Messenger.AddListener("HappyFrigde", HappyFridge); 
        Messenger.AddListener("FridgeFailre", BreakFridge);

        Messenger.AddListener("Ventilate", Ventilate);
        Messenger.AddListener("Smoke more", AddSmoke);
    }

    private void AddSmoke()
    {
        Fog fog;
        m_Volume.profile.TryGet(out fog);

        fog.meanFreePath.value = 45;
    }

    private void Ventilate()
    {
        Fog fog;
        m_Volume.profile.TryGet(out fog);

        fog.enableVolumetricFog.value = false;        
    }

    private void PlantDies()
    {
        PlantOriginal.SetActive(false);
        DeadPlant.SetActive(true);
    }

    private void PlantBlossom()
    {
        FlowerInPlant.SetActive(true);
    }

    private void CleanDishes()
    {
        dishes.SetActive(false);
    }

    private void DirtyDishes()
    {
        dirtyDishes.SetActive(true);
    }

    private void HappyFridge()
    {
        FridgeStickers.SetActive(true);
    }

    private void BreakFridge()
    {
        FridgePuddle.SetActive(true);
    }
}
