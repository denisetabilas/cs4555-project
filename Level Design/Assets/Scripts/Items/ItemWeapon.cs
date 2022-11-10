using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Item", menuName = "Inventory/ItemWeapon")] //create item in the project
public class ItemWeapon : Item
{
     public ItemWeapon() //when item is created this is default attributes
     {
          isEquippable = true; 
     }

     public override void Use()
     {
          base.Use();
          Debug.Log("Equipping weapon " + name);
          EquippedInventory.instance.Add(this);
          Inventory.instance.Remove(this);
     }
}
