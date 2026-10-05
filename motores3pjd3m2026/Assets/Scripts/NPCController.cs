using System;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material material;

    [SerializeField] private NPCDataSO myData;
    

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        material.color = myData.meshColor;
        transform.localScale *= myData.meshSize;
    }
}
