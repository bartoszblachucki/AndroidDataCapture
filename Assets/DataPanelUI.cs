using TMPro;
using UnityEngine;

namespace Visualisation
{
    public class DataPanelUI : MonoBehaviour
    {
        protected void UpdateUI(TextMeshProUGUI text, Vector3? value, string prefix)
        {
            if (value.HasValue)
            {
                text.color = Color.green;
                text.text = Format(value, prefix);
            }
            else
            {
                text.color = Color.red;
                text.text = Format("NO DATA", prefix);
            }
        }

        protected void UpdateUI(TextMeshProUGUI text, float? value, string prefix)
        {
            if (value.HasValue)
            {
                text.color = Color.green;
                text.text = Format(value, prefix);
            }
            else
            {
                text.color = Color.red;
                text.text = Format("NO DATA", prefix);
            }
        }
    
        protected void UpdateUI(TextMeshProUGUI text, Quaternion? value, string prefix)
        {
            if (value.HasValue)
            {
                text.color = Color.green;
                text.text = Format(value, prefix);
            }
            else
            {
                text.color = Color.red;
                text.text = Format("NO DATA", prefix);
            }
        }
    
        private string Format<T>(T value, string prefix)
        {
            return $"{prefix} : {value.ToString()}";
        }
    }
}