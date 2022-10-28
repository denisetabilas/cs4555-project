using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






public class LotosPlayer : MonoBehaviour
{
    public Interactable focus;
    private Animator anim;
    private CharacterController controller;

    Interactable interactable;

    public float speed = 600.0f;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    //public float gravity = 20.0f;


    private bool hasTriggeredNPC; //check if player is colliding with NPC 
    
    private GameObject triggeredNPC;
    public GameObject InstructionText;


     //variables for dialogue 
     public GameObject DiaUI;

     //public GameObject DialogueBox;
     //public GameObject DialogueText;

    /*
    public GameObject spaceShip;
    public Text npcText;
    public GameObject panel;
    public Text dialogueText;


    private int count;
    */
    public bool dialogueOpen;
    
    void Start()
    {
        hasTriggeredNPC = false;
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
        InstructionText.SetActive(false);
          DiaUI.SetActive(false);
         // DialogueBox.SetActive(false);
         // DialogueText.SetActive(false);
        dialogueOpen = false;

        /*
        count = 0;

        SetCount();
        spaceShip.SetActive(false);
        */
    }
    /*
    void SetCount()
    {
        if (count >= 4)
        {
            spaceShip.SetActive(true);
        }
    }*/

    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            anim.SetInteger("AnimationPar", 1);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("AnimationPar", 2);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetInteger("AnimationPar", 2);
        }
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }

        if (hasTriggeredNPC)
        {
            //display instruction to press interact button 
            if (!dialogueOpen) //if player has not yet activated dialogue, display instruction how to activate
            {
                InstructionText.SetActive(true);
               DiaUI.SetActive(false);
               InstructionText.GetComponent<Text>().text = "Press 'E' to Talk"; //replace E with not hard coded thing
                 if (Input.GetButtonDown("Interact"))
                 {
                     if (interactable)
                     {
                         //Debug.Log("focus interactable");
                         SetFocus(interactable);
                     }
                     else
                         Debug.Log("no interactable");
                    InstructionText.SetActive(false);
                    DiaUI.SetActive(true);
                    dialogueOpen = true;
                    Debug.Log("Opened Dialogue");
                 }
            }
            else // the dialogue has been activated 
            {
               if (Input.GetButtonDown("Interact"))
               {
                    FindObjectOfType<DialogueUI>().DisplayNextSentence();
               }
            }
        }
        else
          {
               if (dialogueOpen)
               {
                    if (Input.GetButtonDown("Interact"))
                    {
                         FindObjectOfType<DialogueUI>().DisplayNextSentence();
                    }
               }
          }



        /*
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
        */

    }
    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            //motor.FollowTarget(newFocus);
        }
        Debug.Log("Setting focus");

        newFocus.OnFocused(transform); //notify interactable every click on it 

    }

    void RemoveFocus()
    {
        if (focus != null) //if player is focused on something, notify that we are removing the focus
            focus.OnDefocused();
        focus = null;
        //motor.StopFollowingTarget();
    }


    void OnTriggerEnter(Collider other) //if player is colliding
    {
        Debug.Log("triggered");
        
        if (other.tag == "NPC") //if the object it is colliding with has the tag NPC
        {
               hasTriggeredNPC = true;
               //Debug.Log("Collided with NPC");
                interactable = other.GetComponent<Interactable>();

            /*
         triggering = true; //then it will trigger the event 
         triggeringNpc = other.gameObject; //selecting the npc as the trigger object 
            */
        }
        else if (other.tag == "PickUp")
        {
            //hasTriggeredNPC = true;
            Debug.Log("Collided with PickUp");
            interactable = other.GetComponent<Interactable>();
            if (interactable != null)
            {
                Debug.Log("focus interactable");
                SetFocus(interactable);
            }
            else
                Debug.Log("no interactable");
            //other.gameObject.SetActive(false);
            //count++;
            //SetCount();
        }
    }
    void OnTriggerExit(Collider other) //
    {
        
        if (other.tag == "NPC") 
        {
            //dialogueOpen = false;
            hasTriggeredNPC = false;
            triggeredNPC = null; //not triggering with anything 
            InstructionText.SetActive(false);
            //dialogueOpen = false;
        }
        if (other.tag == "PickUp")
        {
            hasTriggeredNPC = false;
            RemoveFocus();
        }
    }



}