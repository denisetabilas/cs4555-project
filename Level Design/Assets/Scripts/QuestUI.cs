using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
     public GameObject QuUI;
     public TextMeshProUGUI QuestTitle;
     public TextMeshProUGUI QuestDescription;
     public TextMeshProUGUI ItemsListText;
     public TextMeshProUGUI RewardListText; 
     public bool QuestWindowIsOpen;
     public bool isAbleToOpenQuests;


     //temporary variable to store one quest
     //will create quest manager to store multiple quests later 
     public Quest q;

    // Start is called before the first frame update
    void Start()
    {
          //ItemsList = new List<Item>();
          //RewardsList = new List<Item>();
          QuestWindowIsOpen = false;
          isAbleToOpenQuests = false;
          ItemsListText.text = "";
        RewardListText.text = "";
    }
     private void Update()
     {
          if (QuestWindowIsOpen)
          {
               //if the quest window is open, unlock cursor 
               Cursor.lockState = CursorLockMode.None;

               if ( /*Input.GetButtonDown("Interact") ||*/ Input.GetButtonDown("Quest"))
               {
                    CloseQuest();
               }



          }
          else if (isAbleToOpenQuests)
          {
               if(Input.GetButtonDown("Quest"))
               {
                    Cursor.lockState = CursorLockMode.None;
                    QuestWindowIsOpen = true;
                    QuUI.SetActive(true);//unlock cursor
               }
          }
     }

     public void OpenQuest(Quest quest)
     {
          Cursor.lockState = CursorLockMode.None;
          QuestWindowIsOpen = true;
          QuUI.SetActive(true);
          if (q == null)
               q = quest;
          isAbleToOpenQuests = true;
          QuestTitle.text = q.name;
          QuestDescription.text = q.description;
          foreach (Item i in q.itemsToCollect)
          {
               Debug.Log("adding item " + i.name);
               ItemsListText.text += i.name + "\n";
          }
          foreach (Item i in q.itemRewards)
            {
                RewardListText.text += i.name + "\n";
            }
     }

     public void CloseQuest()
     {
          Cursor.lockState = CursorLockMode.Locked;
          QuestWindowIsOpen = false;
          QuUI.SetActive(false);
     }

}
