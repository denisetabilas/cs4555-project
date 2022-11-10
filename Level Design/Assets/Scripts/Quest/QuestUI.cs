using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
     public GameObject QuUI;
     public Transform QuestsParent;
    QuestInventory QInventory;
    QuestSlot[] slots;
    public GameObject OpenedQuestUI;
     public TextMeshProUGUI QuestTitle;
     public TextMeshProUGUI QuestDescription;
     public TextMeshProUGUI ItemsListText;
     public TextMeshProUGUI RewardListText;
    public GameObject QuestInstruction;

     public Quest OpenedQuest;


    // Start is called before the first frame update
    void Start()
    {
        QInventory = QuestInventory.instance;
        QInventory.onItemChangedCallback += UpdateUI;

        slots = QuestsParent.GetComponentsInChildren<QuestSlot>();
        OpenedQuestUI.SetActive(false);
        ItemsListText.text = "";
        RewardListText.text = "";
    }
     private void Update()
     {

        if (Input.GetButtonDown("Quest"))
        {
            QuestInstruction.SetActive(false);
            if (OpenedQuestUI.activeSelf)
            {
                OpenedQuestUI.SetActive(false);
            }
            else if (QuUI.activeSelf)
            {
                QuUI.SetActive(false);
            }
            else
            {
                QuUI.SetActive(true);
            }
            
            if (QuUI.activeSelf || OpenedQuestUI.activeSelf)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }
     }

    void UpdateUI()
    {
        Debug.Log("Updating Quest UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < QInventory.quests.Count)
            {
                slots[i].AddQuest(QInventory.quests[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }

    
     public void OpenQuest(Quest q)
     {
          OpenedQuest = q;
          Debug.Log("OpenedQuest: " + OpenedQuest.name);
          QuUI.SetActive(false);
          OpenedQuestUI.SetActive(true);
          Cursor.lockState = CursorLockMode.None;
          QuestTitle.text = q.name;
          QuestDescription.text = q.description;
        ItemsListText.text = "";
        RewardListText.text = "";
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
          QuUI.SetActive(false);
        OpenedQuestUI.SetActive(false);
          OpenedQuest = null;
     }

     public void FinishQuest()
     {
          Debug.Log("Finishing Quest: " + OpenedQuest.name);


          //check if the required items are in the inventory 
          foreach(Item questItem in OpenedQuest.itemsToCollect)
          {
               bool found = false;
               foreach (Item inv in Inventory.instance.items)
               {
                    if (questItem.name.CompareTo(inv.name) == 0)
                    {
                         found = true;
                         break;
                    }
               }
               foreach (Item equippedItem in EquippedInventory.instance.equippedItems)
               {
                    if (questItem.name.CompareTo(equippedItem.name) == 0)
                    {
                         found = true;
                         break;
                    }
               }
               if (!found)
               {
                    Debug.Log("Item '" + questItem.name + "' is needed to complete the quest.");
                    return;
               }
          }// finished loop means that all items were found

          //check if there is enough space in inventory 
          int InventorySpace = Inventory.instance.space;
          if (InventorySpace - Inventory.instance.items.Count < OpenedQuest.itemRewards.Count) //not enough space in inventory for rewards
          {
               Debug.Log("Unable to finish quest, not enough space in inventoy.");
               return;
          }
          foreach (Item r in OpenedQuest.itemRewards)
          {
               Inventory.instance.Add(r);
          }

          QuestInventory.instance.Remove(OpenedQuest);
          CloseQuest();

     }

    

}
