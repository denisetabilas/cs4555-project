using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedInventory : MonoBehaviour
{

     #region Singleton
     public static EquippedInventory instance;

     void Awake()
     {
          if (instance != null)//found an instance of inventory
          {
               Debug.LogWarning("More than one instance of inventory");
               return;
          }
          instance = this;
     }
     #endregion

     //every time something is changed in the inventory 
     public delegate void OnItemChanged();
     public OnItemChanged onItemChangedCallback;

     public List<Item> equippedItems = new List<Item>();
     public int space = 4; //number of slots in inventory

     public bool Add(Item item)
     {
          //check if item is equippable
          if (item.isEquippable == false) // item is not equippable
          {
               Debug.Log(item.name + " is not able to be equipped.");
               return false;
          }
          if (!item.isDefaultItem)
          {
               if (equippedItems.Count >= space)//reached limit
               {
                    Debug.Log("Not enough space");
                    return false;
               }
               equippedItems.Add(item);
               if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke(); //UI update
          }

        FindObjectOfType<LotosPlayer>().IncreaseDefense(item.AddedDefense);
        


          return true;
     }

     public void Remove(Item item)
     {
          // move back to main inventory

          //items.Remove(item);
          Inventory.instance.Add(item);
          equippedItems.Remove(item);

          if (onItemChangedCallback != null)
               onItemChangedCallback.Invoke(); //UI update   

        FindObjectOfType<LotosPlayer>().DecreaseDefense(item.AddedDefense);
    }
}
