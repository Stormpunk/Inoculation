using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="My Assets/Items/NewItem")]
public class ItemBase : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public void Use()
    {

    }
}
