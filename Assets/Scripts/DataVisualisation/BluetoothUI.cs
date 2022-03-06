using TMPro;
using UnityEngine;

public class BluetoothUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountText;
    
    private void Update()
    {
        if (GameManager.CurrentBluetoothData == null)
            return;

        amountText.text = GameManager.CurrentBluetoothData.Count.ToString();

        foreach (var peripheral in GameManager.CurrentBluetoothData)
        {
            Debug.Log(peripheral.ToString());
        }
    }
}
