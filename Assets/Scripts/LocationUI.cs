using System.Globalization;
using UnityEngine;

public class LocationUI : MonoBehaviour
{
    [SerializeField] private DataUI[] dataUIs;

    private void Update()
    {
        var data = GameManager.CurrentLocationData;
        dataUIs[0].SetData("Latitude", data.latitude.ToString(CultureInfo.InvariantCulture), Color.white);
        dataUIs[1].SetData("Longitude", data.longitude.ToString(CultureInfo.InvariantCulture), Color.white);
        dataUIs[2].SetData("Altitude", data.altitude.ToString(CultureInfo.InvariantCulture), Color.white);
    }
}