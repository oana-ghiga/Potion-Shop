using UnityEngine;
using UnityEngine.UI;

public class counterInventory : MonoBehaviour
{
    [SerializeField]
    private Text _title;

    private int counter = 0;

    private void Start()
    {
        _title.text = "0";
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
