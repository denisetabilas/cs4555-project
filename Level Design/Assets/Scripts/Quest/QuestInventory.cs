using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    contains a list of quests that the player has activated
 */


public class QuestInventory : MonoBehaviour
{
    #region Singleton
    public static QuestInventory instance;

    void Awake()
    {
        if (instance != null)//found an instance of inventory
        {
            Debug.LogWarning("More than one instance of Quest Inventory");
            return;
        }
        instance = this;
    }
    #endregion

    //every time something is changed in the inventory 
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int MaxNumberOfQuests;
    public List<Quest> quests = new List<Quest>();

    public bool Add(Quest q)
    {
        if (quests.Count >= MaxNumberOfQuests)//reached limit
        {
            Debug.Log("Not enough space");
            return false;
        }
        quests.Add(q);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke(); //Quest UI update
        return true;
    }

    public void Remove(Quest q)
    {
        quests.Remove(q);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke(); // Quest UI update
        }

    }


}
