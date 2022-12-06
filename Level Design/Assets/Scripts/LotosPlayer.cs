using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






public class LotosPlayer : MonoBehaviour
{
    public Interactable focus;
    private Animator anim;
    private CharacterController controller;

     public GameObject Helmet;
     public GameObject Sword;

    Interactable interactable;

    public float speed = 600.0f;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    //public float gravity = 20.0f;

    //Set and initialize Health variables
    public int maxHealth = 100;
    public int currHealth;
    public int BaseDefense = 20;
    public int currDefense;
     public int BaseAttack = 5;
     public int currAttack;

    public HealthBar healthBar;
    public DefenseBar defenseBar;
     public AttackBar attackBar;

    private bool hasTriggeredNPC; //check if player is colliding with NPC 
    
    private GameObject triggeredNPC;
    public GameObject InstructionText;

     public GameObject QuestUI;
     public bool hasActivatedQuest;

     //variables for dialogue 
     public GameObject DiaUI;
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
          Helmet.SetActive(false);
          Sword.SetActive(false);

        hasTriggeredNPC = false;
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
        InstructionText.SetActive(false);
        DiaUI.SetActive(false);
        QuestUI.SetActive(false);
        dialogueOpen = false;

        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        defenseBar.SetBaseDefense(BaseDefense);
        currDefense = BaseDefense;
          attackBar.SetBaseAttack(BaseAttack);
          currAttack = BaseAttack;
          
        hasActivatedQuest = false;

    }

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
        else if (Input.GetKey("r"))
        {
            anim.SetInteger("AnimationPar", 3);
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
    public void TakeDamage(int damage)
    {
        currHealth -= damage;

        healthBar.SetHealth(currHealth);
    }

    public void IncreaseDefense(int n)
    {
        currDefense += n;
        defenseBar.SetDefense(currDefense);
    }

    public void DecreaseDefense(int n)
    {
        currDefense -= n;
        defenseBar.SetDefense(currDefense);
    }
     public void IncreaseAttack(int n)
     {
          currAttack += n;
          attackBar.SetAttack(currAttack);
     }
     public void DecreaseAttack(int n)
     {
          currAttack -= n;
          attackBar.SetAttack(currAttack);
     }

     public void EquipHelmet()
     {
          this.Helmet.SetActive(true);
     }
     public void UnequipHelmet()
     {
          this.Helmet.SetActive(false);
     }

     public void EquipSword()
     {
          this.Sword.SetActive(true);
     }

     public void UnequipSword()
     {
          this.Sword.SetActive(false);
     }


}