using TMPro;
using UnityEngine;

namespace DataVisualisation
{
    public class WifiUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI amountText;

        private void Update()
        {
            if (GameManager.CurrentWifiData == null)
                return;

            amountText.text = GameManager.CurrentWifiData.wifiScanResults.Count.ToString();
        }
    }
}