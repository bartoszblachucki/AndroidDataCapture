using TMPro;
using UnityEngine;

namespace DataVisualisation
{
    public class BluetoothUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI amountText;
    
        private void Update()
        {
            if (GameManager.CurrentBluetoothData == null)
                return;

            if (GameManager.CurrentBluetoothData.peripherals == null)
                return;

            amountText.text = GameManager.CurrentBluetoothData.peripherals.Count.ToString();
        }
    }
}
