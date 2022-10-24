using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






public class LotosPlayer : MonoBehaviour
{
     public Interactable focus;
    private Animator anim;
    private CharacterController controller;

    public float speed = 600.0f;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    //public float gravity = 20.0f;



    /*
    private GameObject triggeringNpc;
    private bool triggering; //check if player is colliding with NPC 
    public GameObject spaceShip;
    public Text npcText;
    public GameObject panel;
    public Text dialogueText;


    private int count;
    private bool dialogueOpen = false;
    */
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();

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
        /*
        //if hit right mouse 
        if(Input.GetMouseButtonDown(1))
          {
               //create ray
               Ray ray = cam.ScreenPointToRay(Input.mousePosition);
               RaycastHit hit;

               //if the ray hits 
               if(Physics.Raycast(ray, out hit, 100))
               {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null) //if there actually is an interactable on what is hit 
                    {
                         SetFocus(interactable);
                    }
               }
          }

          //if hit left mouse 
          if (Input.GetMouseButtonDown(0))
          {
               //create ray
               Ray ray = cam.ScreenPointToRay(Input.mousePosition);
               RaycastHit hit;

               //if the ray hits 
               if (Physics.Raycast(ray, out hit, 100))
               {
                    motor.MoveToPoint(hit.point);

                    //stop focus
                    RemoveFocus();
               }
          }*/


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
          focus = newFocus;
     }

     void RemoveFocus()
     {
          focus = null;
     }
    /*
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

    }*/


}
