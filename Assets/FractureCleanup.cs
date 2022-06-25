using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractureCleanup : MonoBehaviour
{
    [SerializeField] GameObject[] Shatters;
    [SerializeField] MeshCollider HoleCollider;
    [SerializeField] GameObject NormalFloor; //original floor

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y   <= -5)
        {
            foreach(GameObject shatter  in Shatters)
            {
                Destroy(shatter);
            }
            NormalFloor.SetActive(true);
            HoleCollider.enabled = true;
            Destroy(gameObject);
        }
    }
}
