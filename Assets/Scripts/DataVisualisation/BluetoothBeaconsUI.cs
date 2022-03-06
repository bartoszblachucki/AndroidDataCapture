using TMPro;
using UnityEngine;

namespace DataVisualisation
{
    public class BluetoothBeaconsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI amountText;

        private void Update()
        {
            if (GameManager.CurrentBluetoothData == null)
                return;
        
            if (GameManager.CurrentBluetoothData.beacons == null)
                return;

            amountText.text = GameManager.CurrentBluetoothData.beacons.Count.ToString();
        }
    }
}