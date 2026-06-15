using System;
using UnityEngine;

public class PortaController : MonoBehaviour
{
    private Animator portaAnim;
    private bool isOpen;
    private bool isInteractable;
    [SerializeField] private Transform interactPoint;
    

    private void Start()
    {
        portaAnim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInteractable)
        {
            isInteractable = true;
            InteractOM.OnInteract += AbreFechaPorta;
            InteractOM.InteractEnabled(isInteractable);
            InteractOM.InteractPosition(interactPoint.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInteractable)
        {
            isInteractable = false;
            InteractOM.OnInteract -= AbreFechaPorta;
            InteractOM.InteractEnabled(isInteractable);
        }
    }

    private void AbreFechaPorta()
    {
        if (!isOpen)
        {
            portaAnim.StopPlayback();
            portaAnim.Play("PortaAbrindo");
            isOpen = true;
        }
        else
        {
            portaAnim.StopPlayback();
            portaAnim.Play("PortaFechando");
            isOpen = false;
        }
    }
}
