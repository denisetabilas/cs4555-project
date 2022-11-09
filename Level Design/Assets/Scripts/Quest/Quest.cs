using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Quest", menuName="Inventory/Quest")] //create item in the project
public class Quest : ScriptableObject
{
    /*
    quest object will store 
        title
        description 
        items to be collected 
        reward   
    */


    new public string name = "New Quest";
    public string description = "Description";
    public List<Item> itemsToCollect = new List<Item>();
    public List<Item> itemRewards = new List<Item>();

    public List<Item> itemsAlreadyCorrected = new List<Item>();

}
