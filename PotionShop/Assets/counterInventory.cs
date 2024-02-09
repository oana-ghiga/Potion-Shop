using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class counterInventory : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _title;

    private int counter = 5;

    private void Start()
    {

        if (_title != null)
        {
            _title.text = "5";
        }
    }

    public void OnButtonClick()
    {
        if (counter > 0)
        {
            counter--;

            _title.text = counter.ToString();
        }
    }

    public void IncrementCounter()
    {
        counter++;

        _title.text = counter.ToString();
    }
}
