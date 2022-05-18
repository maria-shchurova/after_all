using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material OutlineMaterial;
    public bool mouseOver;
    public MeshRenderer outlineObj;

    [SerializeField] string Description;
    [SerializeField] string NegativeResponce;
    [SerializeField] string PositiveResponce;

    private MonologueDisplay display;
    public bool SphereOutline;//for small objets like keys

    public string positiveEventMessage;
    public string negativeEventMessage;
    void Start()
    {
        display = FindObjectOfType<MonologueDisplay>(); 
    }

    void Update()
    {
        if(outlineObj != null)
            outlineObj.enabled = mouseOver;

        if(mouseOver)
        {
            if (Input.GetMouseButton(0))
            {
                display.Display(Description, PositiveResponce, NegativeResponce);
                display.PositiveMessage = positiveEventMessage;
                display.NegativeMessage = negativeEventMessage;

                Destroy(outlineObj);
                Destroy(this);
            }
        }
    }

    private void OnMouseOver()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

}
