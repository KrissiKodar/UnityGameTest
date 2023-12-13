using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CircleRenderer : MonoBehaviour
{
    public Mesh circleMesh;
    public Material circleMaterial;
    public int instanceCount = 10;
    public float circleSize = 1.0f;

    private List<Matrix4x4> matrices = new List<Matrix4x4>();

    void Start()
    {
        for (int i = 0; i < instanceCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0);
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            Vector3 scale = Vector3.one * circleSize;

            Matrix4x4 matrix = Matrix4x4.TRS(position, rotation, scale);
            matrices.Add(matrix);
        }
    }

    void Update()
    {
        if (matrices.Count > 0)
        {
            Graphics.DrawMeshInstanced(circleMesh, 0, circleMaterial, matrices);
        }
    }
}
