using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;


    Inventory inventory;

    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance; //get instance of inventory in current context 
        inventory.onItemChangedCallback += UpdateUI; 

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //getting the children inside the inventory slot object

    }

    // Update is called once per frame
    void Update()
    {
        //open and close inventory window 
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

               if (inventoryUI.activeSelf == true)
                    Cursor.lockState = CursorLockMode.None;
               else
                    Cursor.lockState = CursorLockMode.Locked;
               /*
               if (Cursor.lockState == CursorLockMode.Locked)
               {
                    Cursor.lockState = CursorLockMode.None;
               }
               else
                    Cursor.lockState = CursorLockMode.Locked;
               */

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
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
