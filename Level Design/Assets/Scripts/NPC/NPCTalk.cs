using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalk : Interactable
{
     public NPC npc; //link item to script
     public GameObject InstructionText;
     

     public override void Interact()
     {
          Debug.Log("in NPCTalk");
          base.Interact();
          InstructionText.GetComponent<Text>().text = "Press 'E' to interact";
     }
     private void Update()
     {
          if (Input.GetButtonDown("Interact"))
               Talk();
     }

     void Talk()
     {
        Dialogue d = new Dialogue(npc.name, npc.getDialogue());
        FindObjectOfType<DialogueUI>().StartDialogue(d);
          Debug.Log("Talking with " + npc.name);
     }

}
