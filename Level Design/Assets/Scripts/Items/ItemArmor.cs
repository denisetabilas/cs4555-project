using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor Item", menuName = "Inventory/ItemArmor")] //create item in the project
public class ItemArmor : Item
{

     public ItemArmor() //when item is created this is default attributes
     {
          isEquippable = true;
          isArmor = true;
     }

     public override void Use()
     {
          base.Use();
          Debug.Log("Equipping armor " + name);
          EquippedInventory.instance.Add(this);
          Inventory.instance.Remove(this);
          FindObjectOfType<LotosPlayer>().EquipHelmet();
     }

     public override void Unequip()
     {
          base.Unequip();
          Debug.Log("Unequipping armor.");
          FindObjectOfType<LotosPlayer>().UnequipHelmet();
     }
}
