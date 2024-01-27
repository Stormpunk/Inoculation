using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    //only for the game jam, DO NOT USE FOR FULL DEVELOPMENT
    public static TestInventory instance;

    public int StimGood, StimBad, HealthPack, Antidote, Key;

    private void Awake()
    {
        if(instance!= null)
        {
            Debug.LogError("More than 1 instance!");
        }
        instance = this;
    }
    public void AddToInventory(string itemName)
    {
        if(itemName == "StimGood")
        {
            StimGood++;
        }
        else if(itemName == "StimBad")
        { StimBad++; }
        else if(itemName == "HealthPack")
        {
            HealthPack++;
        }
        else if (itemName == "Antidote")
        {
            Antidote++;
        }
        else if(itemName== "Key")
        {
            Key++;
        }
    }

}
