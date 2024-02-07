using UnityEngine;
using UnityEngine.UI;

public class moneyManagerScript : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;

    private int moneyAmount = 3000;

    private void Start()
    {
        moneyText.text = "Money: " + moneyAmount.ToString();
    }

    public void AddMoney(int amount)
    {
        moneyAmount += amount;
        moneyText.text = "Money: " + moneyAmount.ToString();
    }

    public void SubtractMoney(int amount)
    {
        if (moneyAmount - amount >= 0)
        {
            moneyAmount -= amount;
            moneyText.text = "Money: " + moneyAmount.ToString();
        }
    }

   
}
