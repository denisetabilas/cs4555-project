using UnityEngine;

public class ItemPickup : Interactable
{
     public Item item; //link item to script


     public override void Interact()
     {
          base.Interact();
          PickUp();
     }

     void PickUp()
     {
          Debug.Log("Picking Up " + item.name);

          //add to inventory
          if (Inventory.instance.Add(item))
               Destroy(gameObject);
     }
}
