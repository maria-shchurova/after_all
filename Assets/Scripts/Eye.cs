using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    //[SerializeField] GameObject Canvas;
    [SerializeField] GameObject Eyeball;

    private Transform target;
    //public Vector3 turn;

    void Start()
    {
        target.position = Input.mousePosition;
    }

    void Update()
    {
        //Vector3 turn = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float angle = (Mathf.Atan2(-turn.y, turn.x) * Mathf.Rad2Deg) - 90f;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f,0f,1f);

        //Eyeball.transform.rotation = Input.mousePosition;

        transform.LookAt(target);

    }
       

  
}
