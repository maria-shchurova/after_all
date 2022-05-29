using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRoom : MonoBehaviour
{
    [SerializeField] GameObject current;
    [SerializeField] GameObject next;

    public void Switch()
    {
        current.SetActive(false);
        next.SetActive(true);
    }
}
