using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMeshes : MonoBehaviour
{
    public MeshFilter[] meshesToCombine;
    public Material transparentMaterial;

    private void Start()
    {
        foreach(MeshFilter m in meshesToCombine)
        {
            MeshManager.instance.addMesh(m.transform, m.mesh, m.gameObject.GetComponent<MeshRenderer>().sharedMaterial);
        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            combineAndClear();
    }
    void combineAndClear()
    {
        MeshManager.instance.combineAll();
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
    }
}
