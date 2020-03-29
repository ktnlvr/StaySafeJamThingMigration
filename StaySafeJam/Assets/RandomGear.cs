using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGear : MonoBehaviour
{
    public Mesh[] meshes;

    public void Awake()
    {
        GetComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)];
    }
}
