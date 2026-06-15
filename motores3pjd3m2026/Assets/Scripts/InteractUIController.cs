using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractUIController : MonoBehaviour
{
    private Image interactImage;
    private Vector3 worldPosition;
    private Camera mainCamera;
    private bool isVisible;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        interactImage = GetComponent<Image>();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        InteractOM.OnInteractPosition += UpdatePosition;
        InteractOM.OnInteractEnabled += UpdateVisibility;
    }

    private void UpdateVisibility(bool obj)
    {
        isVisible = obj;
        interactImage.color = isVisible ? Color.white : Color.clear;
    }

    private void UpdatePosition(Vector3 obj)
    {
        worldPosition = obj;
    }

    private void Update()
    {
        if (!isVisible) return;
        rectTransform.position = mainCamera.WorldToScreenPoint(worldPosition);
    }
}
