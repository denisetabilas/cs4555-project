using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestSlot : MonoBehaviour
{
    public TextMeshProUGUI questName;
    //public bool isNew;
    Quest quest;
    public void AddQuest(Quest q)
    {
        quest = q;
        questName.text = q.name;
        questName.enabled = true;
    }


    public void ClearSlot()
    {
        quest = null;
        questName.text = "";
    }

    public void OnSlotButtonPressed()
    {
        //open quest details 
        if (this.quest != null)
        {
            Debug.Log("Opening quest from button: " + this.quest.name);
            FindObjectOfType<QuestUI>().OpenQuest(this.quest);
        }
        else
            Debug.Log("Quest was null");
    }
}
