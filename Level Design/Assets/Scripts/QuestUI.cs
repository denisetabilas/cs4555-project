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
     public List<Item> ItemsList;
     public List<Item> RewardsList;
     public bool QuestWindowIsOpen;
     public bool isAbleToOpenQuests;


     //temporary variable to store one quest
     //will create quest manager later 
     public Quest q;

    // Start is called before the first frame update
    void Start()
    {
          ItemsList = new List<Item>();
          RewardsList = new List<Item>();
          QuestWindowIsOpen = false;
          isAbleToOpenQuests = false;
          ItemsListText.text = "";
    }
     private void Update()
     {
          if (QuestWindowIsOpen)
          {
               if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Quest"))
               {
                    QuestWindowIsOpen = false;
                    QuUI.SetActive(false);
               }
          }
          else if (isAbleToOpenQuests)
          {
               if(Input.GetButtonDown("Quest"))
               {
                    QuestWindowIsOpen = true;
                    QuUI.SetActive(true);
               }
          }
     }

     public void OpenQuest(Quest quest)
     {
          isAbleToOpenQuests = true;
          QuestWindowIsOpen = true;
          QuUI.SetActive(true);
          QuestTitle.text = quest.name;
          QuestDescription.text = quest.description;
          foreach (Item i in quest.itemsToCollect)
          {
               Debug.Log("adding item " + i.name);
               ItemsListText.text += i.name + "\n";
          }
     }

}
