using UnityEngine;
using TMPro;
public class Clients : MonoBehaviour
{

    public GameObject client1;
    public GameObject client2;
    public int i = 0;
    public TMP_Text _title1;
    public TMP_Text _title2;
    public string _title = "";
    public moneyManagerScript money;

    private void Start()
    {
        client1.SetActive(true);
        client2.SetActive(false);
        i = i + 1;
    }

    public void OnButtonClick(Inventory inventory)
    {
        if (i % 2 == 1)
        {
            _title = _title1.text;
        }
        else
        {
            _title = _title2.text;
        }
        Debug.Log(i.ToString());
        Debug.Log(inventory.lastSelectedPotion.NameItem);
        Debug.Log(_title);
        if (inventory.lastSelectedPotion != null && inventory.lastSelectedPotion.NameItem.ToUpper() == _title.ToUpper())
        {
            client1.SetActive(false);
            client2.SetActive(false);
            Debug.Log("Comanda corecta! Primesti banii.");
            money.AddMoney(20);
            if (i % 2 == 0)
            {
                client1.SetActive(true);
            }
            else
            {
                client2.SetActive(true);
            }
            i = i + 1;
        }
        else
        {
            Debug.Log("Comanda gresita!");
        }
       
    }
}
