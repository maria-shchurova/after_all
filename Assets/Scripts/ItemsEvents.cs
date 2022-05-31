using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsEvents : MonoBehaviour
{
    bool playerIsBackInTheRoom = false;
    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener("CleanDishes", CleanDishes); //sent from the dialogue
        Messenger.AddListener("DirtyDishes", DirtyDishes);

        Messenger.AddListener("playerIsBack", playerIsBack);  //sent from the door
    }

    private void CleanDishes()
    {
        //dishes.SetaActive(false);
    }

    private void DirtyDishes()
    {
        //dirtyDishes.SetActive(true);

    }

    // Update is called once per frame
    void playerIsBack()
    {
        playerIsBackInTheRoom = true;
    }
}
