using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName="Inventory/Item")] //create item in the project
public class Item : ScriptableObject
{
     new public string name = "New Item";
     public Sprite icon = null;
     public bool isDefaultItem = false; //default items wont be added to inventory

     public virtual void Use()
     {
          //use item 
          //use actions different for different items 

          Debug.Log("Using " + name);

     }
}
