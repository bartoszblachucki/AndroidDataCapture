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

            UpdateUI(dataUis[0], "Acceleration", data.AccelerometerData);
            UpdateUI(dataUis[1], "Gyro", data.GyroscopeData);
            UpdateUI(dataUis[2], "Gravity", data.GravityData);
            UpdateUI(dataUis[3], "Attitude", data.AttitudeData);
            UpdateUI(dataUis[4], "Linear Acceleration", data.LinearAcceleration);
            UpdateUI(dataUis[5], "Magnetic Field", data.MagneticField);
            UpdateUI(dataUis[6], "Light Level", data.LightLevel);
            UpdateUI(dataUis[7], "Pressure", data.Pressure);
            UpdateUI(dataUis[8], "Proximity", data.Proximity);
            UpdateUI(dataUis[9], "Humidity", data.Humidity);
            UpdateUI(dataUis[10], "Ambient Temp", data.AmbientTemperature);
            UpdateUI(dataUis[11], "Step Counter", data.StepCounter);
        }
    }
}