using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void Back()
    {
        GameObject.Find("FishEyeCam").SetActive(false);
        GameObject.Find("Main Camera").SetActive(true);
        GameObject.Find("FishEyeVol").SetActive(false);
    }
}
