using UnityEngine;

namespace DataVisualisation
{
    public class SensorsUI : DataPanelUI
    {
        [SerializeField] private DataUI[] dataUis;

        private void Update()
        {
            var data = GameManager.CurrentSensorData;
            if (data == null)
                return;

            UpdateUI(dataUis[0], "Acceleration", data.accelerometerData);
            UpdateUI(dataUis[1], "Gyro", data.gyroscopeData);
            UpdateUI(dataUis[2], "Gravity", data.gravityData);
            UpdateUI(dataUis[3], "Attitude", data.attitudeData);
            UpdateUI(dataUis[4], "Linear Acceleration", data.linearAcceleration);
            UpdateUI(dataUis[5], "Magnetic Field", data.magneticField);
            UpdateUI(dataUis[6], "Light Level", data.lightLevel);
            UpdateUI(dataUis[7], "Pressure", data.pressure);
            UpdateUI(dataUis[8], "Proximity", data.proximity);
            UpdateUI(dataUis[9], "Humidity", data.humidity);
            UpdateUI(dataUis[10], "Ambient Temp", data.ambientTemperature);
            UpdateUI(dataUis[11], "Step Counter", data.stepCounter);
        }
    }
}