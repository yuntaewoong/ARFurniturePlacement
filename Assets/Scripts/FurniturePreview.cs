using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class FurniturePreview : MonoBehaviour
{
    
    public Material materialOnNoCollision;
    public Material materialOnCollisionMesh;

    private MeshRenderer meshRenderer;
    private int counter = 0;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnEnable()
    {
        counter++;
        if (counter < 60)
            return;
        counter = 0;
        Debug.Log("Change To Green");
        Material[] materials = meshRenderer.materials;
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = materialOnNoCollision;
        }
        meshRenderer.SetMaterials(materials.ToList());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("GlobalMesh"))
        {
            Debug.Log("Change To Red");
            Material[] materials = meshRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = materialOnCollisionMesh;
            }
            meshRenderer.SetMaterials(materials.ToList());
        }
    }

}
