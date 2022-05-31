using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : MonoBehaviour
{
    [SerializeField] GameObject DirtyDishes;
    [SerializeField] GameObject FlowerInPlant;
    [SerializeField] GameObject PlantOriginal;
    [SerializeField] GameObject DeadPlant;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if (MoodKeeper.DirtyDishes == true)
            DirtyDishes.SetActive(true);

        if (MoodKeeper.PlantBloom == true)
            FlowerInPlant.SetActive(true);

        if (MoodKeeper.PlantDied == true) 
        {
            PlantOriginal.SetActive(false);
            DeadPlant.SetActive(true);
        }


    }
    void Update()
    {
        
    }
}
