using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName="Inventory/Item")] //create item in the project
public class Item : ScriptableObject
{
     new public string name = "New Item";
     public Sprite icon = null;
     public bool isDefaultItem = false; //default items wont be added to inventory
     public bool isEquippable = false; //default item created is not able to be equipped 
     public int AddedDefense = 0;
    public int AddedAttack = 0;
     public bool isWeapon = false;
     public bool isArmor = false;

    public virtual void Use()
     {
          //use item 
          //use actions different for different items 
          Debug.Log("Using " + name);
     }

     public virtual void Unequip()
     {
          // only for equippable items
          if (isEquippable)
               Debug.Log("Unequipping " + name);
          else
               return;
     }
}
