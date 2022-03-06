using TMPro;
using UnityEngine;

public class BluetoothBeaconsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI amountText;
    
    private void Update()
    {
        if (GameManager.CurrentBluetoothBeaconsData == null)
            return;

        amountText.text = GameManager.CurrentBluetoothBeaconsData.Count.ToString();

        foreach (var peripheral in GameManager.CurrentBluetoothBeaconsData)
        {
            Debug.Log(peripheral.ToString());
        }
    }
}