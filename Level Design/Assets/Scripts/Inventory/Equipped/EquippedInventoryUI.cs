using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedInventoryUI : MonoBehaviour
{
     public Transform equippedItemsParent;
     public GameObject EInventoryUI;


     EquippedInventory eInventory;

     EquippedInventorySlot[] slots;
     // Start is called before the first frame update
     void Start()
     {
          eInventory = EquippedInventory.instance; //get instance of inventory in current context 
          eInventory.onItemChangedCallback += UpdateUI;

          slots = equippedItemsParent.GetComponentsInChildren<EquippedInventorySlot>(); //getting the children inside the inventory slot object

     }

     // Update is called once per frame
     void Update()
     {
          //open and close inventory window 
          if (Input.GetButtonDown("Inventory"))
          {
               EInventoryUI.SetActive(!EInventoryUI.activeSelf);
               /*
               if (Cursor.lockState == CursorLockMode.Locked)
               {
                    Cursor.lockState = CursorLockMode.None;
               }
               else
                    Cursor.lockState = CursorLockMode.Locked;*/

          }
     }


     //every time something is added or removed from the 
     //quest inventory, call this method
     void UpdateUI()
     {
          Debug.Log("UPDATING UI");
          //find all of the inventory slots 
          for (int i = 0; i < slots.Length; i++)
          {
               if (i < eInventory.equippedItems.Count)
               {
                    slots[i].AddItem(eInventory.equippedItems[i]);
               }
               else
               {
                    slots[i].ClearSlot();
               }
          }

     }
}
