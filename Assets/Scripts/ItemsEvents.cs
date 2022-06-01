using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsEvents : MonoBehaviour
{
    [SerializeField] GameObject dishes;
    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener("CleanDishes", CleanDishes); //sent from the dialogue
        Messenger.AddListener("DirtyDishes", DirtyDishes);

        Messenger.AddListener("FlowerInPlant", PlantBlossom); //sent from the dialogue
        Messenger.AddListener("DeadPlant", PlantDies);

        Messenger.AddListener("HappyFrigde", PlantBlossom); //sent from the dialogue
        Messenger.AddListener("FridgeFailre", BreakFridge);
    }

    private void PlantDies()
    {
        MoodKeeper.PlantDied = true;
    }

    private void PlantBlossom()
    {
        MoodKeeper.PlantBloom = true;
    }

    private void CleanDishes()
    {
        dishes.SetActive(false);
    }

    private void DirtyDishes()
    {
        MoodKeeper.DirtyDishes = true;
    }

    private void HappyFridge()
    {
        MoodKeeper.FridgeStickers = true;
    }

    private void BreakFridge()
    {
        MoodKeeper.FridgeBreaks = true;
    }
}
