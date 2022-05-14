using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material OutlineMaterial;
    public bool mouseOver;
    GameObject outlineObj;

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

        if (transform.parent == null)// to avoid recursion
        {
            CreateSelf();
            if (SphereOutline)
                GetComponent<MeshRenderer>().enabled = false;
        }
        else if (transform.parent.name != transform.name)
        {
            CreateSelf();
        }
        else
            return;

    }

    void CreateSelf()
    {
        outlineObj = Instantiate(gameObject);
        outlineObj.name = transform.name;

        outlineObj.transform.parent = transform;
        outlineObj.transform.localScale = new Vector3(-1, 1, 1);
        outlineObj.GetComponent<MeshRenderer>().material = OutlineMaterial;
        Destroy(outlineObj.GetComponent<BoxCollider>());
        Destroy(outlineObj.GetComponent<Interactable>());

        outlineObj.SetActive(false);
    }

    void Update()
    {
        if(outlineObj != null)
            outlineObj.SetActive(mouseOver);

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
