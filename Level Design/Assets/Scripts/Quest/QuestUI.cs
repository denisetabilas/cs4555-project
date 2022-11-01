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

    //public TextMeshProUGUI QuestInstrText;
    //private bool QuestInstructionDisplayed;
     //public bool QuestWindowIsOpen;
     //public bool isAbleToOpenQuests;


    // Start is called before the first frame update
    void Start()
    {
        QInventory = QuestInventory.instance;
        QInventory.onItemChangedCallback += UpdateUI;

        slots = QuestsParent.GetComponentsInChildren<QuestSlot>();
        OpenedQuestUI.SetActive(false);
        ItemsListText.text = "";
        RewardListText.text = "";
        //QuestInstructionDisplayed = false;


          //ItemsList = new List<Item>();
          //RewardsList = new List<Item>();
        /*
        QuestWindowIsOpen = false;
        isAbleToOpenQuests = false;*/
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
     }
    /*
    */

    

}
