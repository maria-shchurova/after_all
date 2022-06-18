using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactToSound : MonoBehaviour
{
    public List<Light> lightReactingToBass;
    [SerializeField] float t = 0.1f;
    [SerializeField] float multiplierMin = 10f;
    [SerializeField] float multiplierMax = 10f;
    [SerializeField] MusicManager manager;

    void FixedUpdate()
    {
        Dance();
    }

    void Dance()
    {
        if(manager.audioSource.isPlaying)
        {
            foreach (Light light in lightReactingToBass)
            {
                light.range = Mathf.Lerp(light.range, manager.GetFrequencesDiapason(0, 7, 10) * Random.Range(multiplierMin, multiplierMax - 10), t);
            }
        }
        else
        {
            foreach (Light light in lightReactingToBass)
            {
                light.range = multiplierMax;
            }
        }

        
    }
}
