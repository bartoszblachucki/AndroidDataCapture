using UnityCommon;
using UnityEngine;

namespace DataVisualisation
{
    public class DataPanelUI : MonoBehaviour
    {
        protected void UpdateUI(DataUI dataUI, string label, Nullable<Vector3> value)
        {
            if (value.HasValue)
            {
                dataUI.SetData(label, value.ToString(), Color.green);
            }
            else
            {
                dataUI.SetData(label, "NO DATA", Color.red);
            }
        }

        protected void UpdateUI(DataUI dataUI, string label, Nullable<float> value)
        {
            if (value.HasValue)
            {
                dataUI.SetData(label, value.ToString(), Color.green);
            }
            else
            {
                dataUI.SetData(label, "NO DATA", Color.red);
            }
        }

        protected void UpdateUI(DataUI dataUI, string label, Nullable<Quaternion> value)
        {
            if (value.HasValue)
            {
                dataUI.SetData(label, value.ToString(), Color.green);
            }
            else
            {
                dataUI.SetData(label, "NO DATA", Color.red);
            }
        }

        private string Format<T>(T value, string prefix)
        {
            return $"{prefix} : {value.ToString()}";
        }
    }
}