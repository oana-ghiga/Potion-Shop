using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Cauldron : MonoBehaviour
{
    private Dictionary<string, int> ingredientsCount = new Dictionary<string, int>();

    public GameObject poisonPotionPrefab;
    public GameObject healthPotionPrefab;
    public GameObject manaPotionPrefab;
    public GameObject lightPotionPrefab;
    public GameObject frostPotionPrefab;
    public GameObject charmPotionPrefab;
    public GameObject explosionPotionPrefab;
    public GameObject memoryRecoverPotionPrefab;

    public Transform potionSpawnLocation;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Obiect in contact cu ceaunul");
            string ingredientBaseName = ExtractBaseName(other.gameObject.name);
            if (ingredientsCount.ContainsKey(ingredientBaseName))
            {
                ingredientsCount[ingredientBaseName]++;
            }
            else
            {
                ingredientsCount.Add(ingredientBaseName, 1);
            }

            Destroy(other.gameObject);
            CheckPotionRecipe();
        }
        
        void CheckPotionRecipe()
        {
        CheckPoisonPotion();
        CheckHealthPotion();
        CheckManaPotion();
        CheckLightPotion();
        CheckFrostPotion();
        CheckCharmPotion();
        CheckExplosionPotion();
        CheckMemoryRecoverPotion();
        }

    }

    string ExtractBaseName(string name)
    {
        return Regex.Replace(name, @" \(\d+\)$", "");
    }

   

    bool HasIngredients(Dictionary<string, int> requiredIngredients)
    {
    foreach (var item in requiredIngredients)
    {
        if (!ingredientsCount.ContainsKey(item.Key) || ingredientsCount[item.Key] < item.Value)
        {
            Debug.Log("Lacking ingredient or not enough: " + item.Key);
            return false;
        }
    }

    foreach (var item in requiredIngredients)
    {
        ingredientsCount[item.Key] -= item.Value;
        RemoveIngredientIfEmpty(item.Key);
    }

    return true;
    }

    void CreatePotion(GameObject potionPrefab)
    {
    Vector3 spawnPosition = transform.position + transform.forward * 2.0f + transform.up * 4.0f; 
    Debug.Log("Creating potion at: " + spawnPosition.ToString());
    Instantiate(potionPrefab, spawnPosition, Quaternion.identity);
    }


    void RemoveIngredientIfEmpty(string ingredientName)
    {
        if (ingredientsCount[ingredientName] == 0)
        {
            ingredientsCount.Remove(ingredientName);
        }
    }

    void CheckPoisonPotion()
    {
        Debug.Log("Checking for Poison Potion");
        if (HasIngredients(new Dictionary<string, int> { { "Nether Wart", 1 }, { "Deathweed", 1 }, { "bat_wing", 1 } }))
        {
            Debug.Log("Poison Potion has been created!");
            CreatePotion(poisonPotionPrefab);
        }
    }

    void CheckHealthPotion()
    {
        if (HasIngredients(new Dictionary<string, int> { { "Essence of life", 1 }, { "VampireBlood", 1 }, { "Lifeleaf", 1 } }))
        {
            Debug.Log("Health Potion has been created!");
            CreatePotion(healthPotionPrefab);
        }
    }

    void CheckManaPotion()
    {
        if (HasIngredients(new Dictionary<string, int> { { "ShadowChantelle", 1 }, { "Pixie Dust", 1 }, { "Unicorn Horn", 1 } }))
        {
            Debug.Log("Mana Potion has been created!");
            CreatePotion(manaPotionPrefab);
        }
    }

    void CheckLightPotion()
    {
        if (HasIngredients(new Dictionary<string, int> { { "Daybloom", 1 }, { "Soul of blight", 1 }, { "Glowing Mushroom", 1 } }))
        {
            Debug.Log("Light Potion has been created!");
            CreatePotion(lightPotionPrefab);
        }
    }

    void CheckFrostPotion()
    {
        if (HasIngredients(new Dictionary<string, int> { { "Water", 1 }, { "Sapphire Dust", 1 }, { "Ice Fruit", 1 } }))
        {
            Debug.Log("Frost Potion has been created!");
            CreatePotion(frostPotionPrefab);
        }
    }

    void CheckCharmPotion()
    {
        if (HasIngredients(new Dictionary<string, int> { { "Ghast Tears", 1 }, { "Oil", 1 }, { "Lustshroom", 1 } }))
        {
            Debug.Log("Charm Potion has been created!");
            CreatePotion(charmPotionPrefab);
        }
    }

    void CheckExplosionPotion()
    {
        if (HasIngredients(new Dictionary<string, int> { { "Fireblossom", 1 }, { "Hellfire Essence", 1 }, { "Blaze Powder", 1 } }))
        {
            Debug.Log("Explosion Potion has been created!");
            CreatePotion(explosionPotionPrefab);
        }
    }

    void CheckMemoryRecoverPotion()
    {
        if (HasIngredients(new Dictionary<string, int> { { "Tangleweed", 1 }, { "Rainbow Flakes", 1 }, { "Cloud Citrine", 1 } }))
        {
            Debug.Log("Memory Recover Potion has been created!");
            CreatePotion(memoryRecoverPotionPrefab);
        }
    }
}

