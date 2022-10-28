using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalk : Interactable
{
     public NPC npc;
     public GameObject InstructionText;

     private void Start()
     {
     }

     public override void Interact()
     {
          Debug.Log("in NPCTalk");
          base.Interact();
          Talk();
          
     }

     void Talk()
     {
          Debug.Log("Talking with " + npc.name);
          FindObjectOfType<DialogueUI>().StartDialogue(npc);
          /*
          Dialogue d;
          if (!hasMet)
          { 
               d = new Dialogue(npc.name, npc.firstDialogue);
               hasMet = true;
          }
          else
               d = new Dialogue(npc.name, npc.defaultDialogue);
          FindObjectOfType<DialogueUI>().StartDialogue(d, npc.hasQuest);
          */
     }

}
