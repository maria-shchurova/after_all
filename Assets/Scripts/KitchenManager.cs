using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        Messenger.AddListener("CleanDishes", CleanDishes);
        Messenger.AddListener("DirtyDishes", DirtyDishes);

        Messenger.AddListener("FlowerInPlant", PlantBlossom); 
        Messenger.AddListener("DeadPlant", PlantDies);

        Messenger.AddListener("HappyFrigde", HappyFridge); 
        Messenger.AddListener("FridgeFailre", BreakFridge);
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
