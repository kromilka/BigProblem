using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject inventory;
    private bool inventoryOn;

    private void Start()
    {
        inventoryOn = false;
    }

    public void Chest()
    {
        if(!inventoryOn)
        {
            inventoryOn = true;
            inventory.SetActive(true);
        }
        else if (inventoryOn)
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }
    static bool created = false;

    
}
