using UnityEngine;
using System.Collections.Generic;

public class Chest : MonoBehaviour
{
    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    [SerializeField] private InventoryUI inventoryUI;

    private void Start()
    {
        if (inventoryUI != null)
        {
            inventoryUI.UpdateInventoryUI();
        }
    }

    public void AddPotion(string potionName)
    {
        if (inventory.ContainsKey(potionName))
        {
            inventory[potionName]++;
        }
        else
        {
            inventory.Add(potionName, 1);
        }

        Debug.Log($"Potiunea {potionName} a fost adaugata. Acum ai {inventory[potionName]} din aceasta.");

        if (inventoryUI != null)
        {
            inventoryUI.UpdateInventoryUI();
        }
    }

    public void PrintInventory()
    {
        foreach (var item in inventory)
        {
            Debug.Log($"{item.Key}: {item.Value}");
        }
    }
}
