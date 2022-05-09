using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PositionID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

    public Material WallMaterial;
    public Camera Camera;
    public LayerMask CollisionMask;
    void Update()
    {
        if (Camera == null)
            return;

        var dir = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if (Physics.Raycast(ray, 3000, CollisionMask))
            WallMaterial.SetFloat(SizeID, 12);
        else
            WallMaterial.SetFloat(SizeID, 0);

        var view = Camera.WorldToViewportPoint(transform.position);
        WallMaterial.SetVector(PositionID, view);
    }
}
