using System;
using UnityEngine;

public static class InteractOM
{
   public static event Action OnInteract;

   public static void Interact()
   {
      OnInteract?.Invoke();
   }

   public static event Action<Vector3> OnInteractPosition;
   
   public static void InteractPosition(Vector3 position)
   {
      OnInteractPosition?.Invoke(position);
   }
   
   public static event Action<bool> OnInteractEnabled;

   public static void InteractEnabled(bool enabled)
   {
      OnInteractEnabled?.Invoke(enabled);
   }
}
