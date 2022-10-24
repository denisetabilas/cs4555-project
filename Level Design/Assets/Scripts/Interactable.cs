using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
     public float radius = 3f; //how close player needs to be 
     bool isFocus = false;
     Transform player;

     bool hasInteracted = false;
     public Transform interactionTransform;//player has to be at a certain position to interact 
                                           //create new empty object, move it to wherever, and set that empty object into this interactionTransform slot
                                           //can also put the transform of the same object into this to get rid of error

     //all objects derive from this class, except how we interact to the object
     //virtual means that objects that are derived from this class has different action inside the virtual method
     //virtual methods are meant to be overrided 

     public virtual void Interact()
     {
          Debug.Log("Interacting with " + transform.name);
     }

     private void Update()
     {
          if (isFocus)
          {
               float distance = Vector3.Distance(player.position, interactionTransform.position);

               //if player is within radius and has not interacted with interactable yet
               if (distance <= radius && !hasInteracted)
               {
                    Interact();
                    hasInteracted = true;
               }
          }
     }

     public void OnFocused(Transform playerTransform)
     {
          isFocus = true;
          player = playerTransform;
          hasInteracted = false; //every time focus on object, only do it once 
     }

     public void OnDefocused()
     {
          isFocus = false;
          player = null;
          hasInteracted = false;
     }

     void OnDrawGizmosSelected ()
     {
          //if there in no interaction transform, set it to its own transform 
          if (interactionTransform == null)
          {
               interactionTransform = transform;
          }

          Gizmos.color = Color.yellow;
          Gizmos.DrawWireSphere(transform.position, radius);
     }
}
