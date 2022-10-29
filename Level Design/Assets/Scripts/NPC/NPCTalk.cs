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
        npc.hasQuest = true;
        npc.hasMet = false;
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
     }

}
