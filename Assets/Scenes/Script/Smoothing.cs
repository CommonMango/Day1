using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Smoothing : MonoBehaviour
{ 
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.RecalculateNormals();
    }

    
}
