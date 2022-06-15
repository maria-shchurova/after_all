using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayManager : MonoBehaviour
{
    [SerializeField] GameObject RedHornsGrowth;
    [SerializeField] GameObject HairGrowth;
    

    // Start is called before the first frame update
    void Start()
    {
        Messenger.AddListener("RedHorns", RedHorns);
        Messenger.AddListener("Hair", Hair);
    }

    void RedHorns()
    {
        RedHornsGrowth.SetActive(true);
    }

    void Hair()
    {
        HairGrowth.SetActive(true);
    }

}
