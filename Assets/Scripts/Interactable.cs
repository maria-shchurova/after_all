using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material OutlineMaterial;
    public bool mouseOver;
    GameObject outlineObj;
    void Start()
    {
        if (transform.parent == null)// to avoid recursion
        {
            CreateSelf();
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
