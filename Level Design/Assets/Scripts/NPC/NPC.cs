using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New NPC", menuName="Inventory/NPC")] 
public class NPC : ScriptableObject
{
     /*
          store values for NPC
               name 
               firstDialogue --> if hasMet == false, this dialogue will print
               hasMet --> true or false, player has met this NPC
               defaultDialogue --> if hasMet == true, this dialogue will print
      */
     new public string name = "New NPC";
     public List<string> firstDialogue = new List<string>();
     public List<string> defaultDialogue = new List<string>();

     private bool hasMet = false; 

     public List<string> getDialogue()
     {
          if (hasMet == false)
          {
               hasMet = true;
               return firstDialogue;
          }
          return defaultDialogue;
     }
}
