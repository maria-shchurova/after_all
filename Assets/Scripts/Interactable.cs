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
        outlineObj = Instantiate(gameObject);
        outlineObj.transform.parent = transform;
        outlineObj.transform.localScale = new Vector3(-1, 1, 1);
        outlineObj.GetComponent<MeshRenderer>().material = OutlineMaterial;
        Destroy(outlineObj.GetComponent<BoxCollider>());

        outlineObj.SetActive(false);
    }

    void Update()
    {
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
