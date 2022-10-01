using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameObject triggeringNpc;
    private bool triggering; //check if player is colliding with NPC 
    public GameObject spaceShip;

    public Text npcText;
    public GameObject panel;
    public Text dialogueText;


    private int count;
    private bool dialogueOpen = false;

    void Start()
    {
        count = 0;

        SetCount();
        spaceShip.SetActive(false);
    }

    void SetCount()
    {
        if (count >= 4)
        {
            spaceShip.SetActive(true);
        }
    }

    void Update()
    {
        if (triggering)
        {
            //print("Player is triggering with " + triggeringNpc); //for testing 
            //npcText.SetActive(true);
            if(dialogueOpen)
                npcText.text = "";
            else
                npcText.text = "Press 'E'";
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (dialogueOpen == false)
                {
                    dialogueOpen = true;
                    panel.SetActive(true);
                    dialogueText.text = "Collect the Spaceship Parts!";
                    npcText.text = "";
                }
                else
                    npcText.text = "Press 'E'";
            }

            if (Input.GetKeyDown(KeyCode.F) &&  dialogueOpen)
            {
                dialogueOpen = false;
                dialogueText.text = "";
                panel.SetActive(false);
            }
        }
        else
        {
            npcText.text = "";
            dialogueText.text = "";
            panel.SetActive(false);
        }

    }

    void OnTriggerEnter (Collider other) //if player is colliding
    {
        if (other.tag == "NPC") //if the object it is colliding with has the tag NPC
        {
            triggering = true; //then it will trigger the event 
            triggeringNpc = other.gameObject; //selecting the npc as the trigger object 
        }
        else if(other.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCount();
        }
    }
    void OnTriggerExit(Collider other) //
    {
        if (other.tag == "NPC") 
        {
            dialogueOpen = false;
            triggering = false;
            triggeringNpc = null; //not triggering with anything 
        }

    }


}
