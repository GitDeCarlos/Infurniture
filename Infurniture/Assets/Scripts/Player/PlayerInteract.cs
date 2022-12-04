using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
   public GameObject currentInteractableObj= null;

   void Start()
   {
      
   }

   void Update()
   {
      if(Input.GetButtonDown("Interact") && currentInteractableObj) // editted Input Manager
      {
         Debug.Log("Interacted");
         // do something with the object, can change/add other scenarios
         currentInteractableObj.SendMessage("DoInteraction");
      }
   }

   // runs when player walks into trigger collider
   void OnTriggerEnter2D(Collider2D  other)
   {
      // check if collided object is an interactableObject
      if(other.CompareTag("interactableObject"))
      {
         Debug.Log(other.name);

         currentInteractableObj = other.gameObject;
      }

   }

   // runs when player walks out of range of trigger collider
   void OnTriggerExit2D(Collider2D other)
   {
      // check if collided object is an interactableObject
      if(other.CompareTag("interactableObject"))
      {
         if(other.gameObject == currentInteractableObj)
         {
            currentInteractableObj = null;
         }
      }
   }
}
