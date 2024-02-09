using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Potion lastSelectedPotion;

    public void SelectPotion(Potion potion)
    {
        lastSelectedPotion = potion;

    }
}
