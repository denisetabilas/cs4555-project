using UnityEngine;

public class ItemPickup : Interactable
{
     public Item item; //link item to script


     public override void Interact()
     {
          base.Interact();
          PickUp();
        Debug.Log("picked up");
     }

     void PickUp()
     {
          //add to inventory
          if (item != null)
          {
               Debug.Log("Picking Up " + item.name);

               if (Inventory.instance.Add(item))
                    Destroy(gameObject);
          }
          else return;
     }
}
