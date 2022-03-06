using TMPro;
using UnityEngine;

namespace DataVisualisation
{
    public class DataUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI labelText;
        [SerializeField] private TextMeshProUGUI valueText;

        public void SetData(string label, string value, Color color)
        {
            labelText.text = label;
            valueText.text = value;
            labelText.color = color;
            valueText.color = color;
        }
    }
}
