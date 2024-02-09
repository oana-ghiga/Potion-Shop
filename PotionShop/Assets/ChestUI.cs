using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Chest chest; 
    public GameObject inventoryPanel; 
    public GameObject inventoryItemPrefab; 

    private void Start()
    {
        if (chest != null)
        {
            UpdateInventoryUI();
        }
        else
        {
            Debug.LogError("Referinta la Chest nu a fost setata în InventoryUI.");
        }
    }

    public void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (KeyValuePair<string, int> entry in chest.inventory)
        {
            GameObject itemGO = Instantiate(inventoryItemPrefab, inventoryPanel.transform);
            Text itemText = itemGO.GetComponentInChildren<Text>();
            if (itemText != null)
            {
                itemText.text = $"{entry.Key}: {entry.Value}";
            }
            else
            {
                Debug.LogError("Prefabul Inventory Item nu are un component Text.");
            }
        }
    }
}
