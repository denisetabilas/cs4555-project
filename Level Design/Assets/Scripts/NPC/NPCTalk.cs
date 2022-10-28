using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalk : Interactable
{
     public NPC npc; //link item to script
     public GameObject InstructionText;
     private bool hasMet;


     private void Start()
     {
          hasMet = false;
     }

     public override void Interact()
     {
          Debug.Log("in NPCTalk");
          base.Interact();
          Talk();
          //InstructionText.GetComponent<Text>().text = "Press 'E' to interact";
     }
     /*
     private void Update()
     {
          if (Input.GetButtonDown("Interact"))
               Talk();
     }*/

     void Talk()
     {
          Dialogue d;
          if (!hasMet)
          { 
               d = new Dialogue(npc.name, npc.firstDialogue);
               hasMet = true;
          }
          else
               d = new Dialogue(npc.name, npc.defaultDialogue);
          Debug.Log("Talking with " + npc.name);
        FindObjectOfType<DialogueUI>().StartDialogue(d);
     }

}
