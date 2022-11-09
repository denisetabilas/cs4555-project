using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
     #region Singleton
     public static Inventory instance;

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

     public List<Item> items = new List<Item>();
     public int space = 20; //number of slots in inventory

     public bool Add(Item item)
     {
          if(!item.isDefaultItem)
          {
               if (items.Count >= space)//reached limit
               {
                    Debug.Log("Not enough space");
                    return false;
               }
               items.Add(item);
               if (onItemChangedCallback != null)
                    onItemChangedCallback.Invoke(); //UI update
          }
          return true;
     }

     public void Remove(Item item)
     {
          items.Remove(item);


          if (onItemChangedCallback != null)
               onItemChangedCallback.Invoke(); //UI update   
     }
}
