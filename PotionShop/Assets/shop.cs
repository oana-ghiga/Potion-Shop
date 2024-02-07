using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    [SerializeField]
    private GameObject gameManagerCoins;

    [SerializeField]
    private Text price;

    private bool enought = true;

    public void OnButtonClicked()
    {
        if (gameManager != null)
        {
            counterInventory counterScript = gameManager.GetComponent<counterInventory>();
            moneyManagerScript counterMoney = gameManagerCoins.GetComponent<moneyManagerScript>();

            if (counterScript != null)
            {
                enought = counterMoney.SubtractMoney(ConvertStringWithoutLastCharToInt(price.text));
                if (enought)
                {
                    counterScript.IncrementCounter();
                }
            }
            else
            {
                Debug.LogError("counterInventory script not found on GameManager.");
            }
        }
        else
        {
            Debug.LogError("GameManager is not assigned to the shop script.");
        }

    }

    static int ConvertStringWithoutLastCharToInt(string input)
    {
        if (input.Length > 0)
        {
            string substring = input.Substring(0, input.Length - 1);

            if (int.TryParse(substring, out int result))
            {
                return result;
            }
        }
        return 0;
    }
}
