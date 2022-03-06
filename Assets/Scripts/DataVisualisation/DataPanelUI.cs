using UnityEngine;

public class DataPanelUI : MonoBehaviour
{
    protected void UpdateUI(DataUI dataUI, string label, Vector3? value)
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

    protected void UpdateUI(DataUI dataUI, string label, float? value)
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

    protected void UpdateUI(DataUI dataUI, string label, Quaternion? value)
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