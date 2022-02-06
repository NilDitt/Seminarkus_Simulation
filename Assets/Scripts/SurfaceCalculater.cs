using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceCalculater : MonoBehaviour
{
    //public Mesh = GetComponent<MeshFilter>();
    private void Start()
    {
        var MeshFilter = GetComponent<MeshFilter>();
        var SurfaceArea = CalculateSurfaceArea(MeshFilter.mesh);
        print("The Object: " + gameObject.name +  " has a surface Area of: " + SurfaceArea);

        var ObjectsScr = GetComponent<Objects>();
        ObjectsScr.surfaceArea = SurfaceArea;
    }
    float CalculateSurfaceArea(Mesh mesh)
    {
        var triangles = mesh.triangles;
        var vertices = mesh.vertices;

        double sum = 0.0;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            Vector3 corner = vertices[triangles[i]];
            Vector3 a = vertices[triangles[i + 1]] - corner;
            Vector3 b = vertices[triangles[i + 2]] - corner;

            sum += Vector3.Cross(a, b).magnitude;
        }

        return (float)(sum / 2.0);
    }
}
