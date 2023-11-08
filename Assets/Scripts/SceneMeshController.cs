using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMeshController : MonoBehaviour
{
    public Material SceneMeshMaterial;

    private GameObject SceneMesh;

    public void OnSceneMeshLoaded()
    {
        Debug.Log("Testing");
        GameObject[] meshObjects = GameObject.FindGameObjectsWithTag("GlobalMesh");
        foreach(var meshObject in meshObjects)
        {
            if(meshObject.name.StartsWith("GameSceneMesh"))
            {
                SceneMesh = meshObject;
            }
        }

        MeshRenderer meshRenderer = SceneMesh.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;
        meshRenderer.material = SceneMeshMaterial;

    }
}
