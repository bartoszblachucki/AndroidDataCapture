using TMPro;
using UnityEngine;

namespace Visualisation
{
    public class SensorsUI : DataPanelUI
    {
        [SerializeField] private TextMeshProUGUI accelerometerText;
        [SerializeField] private TextMeshProUGUI gyroscopeText;
        [SerializeField] private TextMeshProUGUI gravityText;
        [SerializeField] private TextMeshProUGUI attitudeText;
        [SerializeField] private TextMeshProUGUI linearAccelerationText;
        [SerializeField] private TextMeshProUGUI magneticFieldText;
        [SerializeField] private TextMeshProUGUI lightLevelText;
        [SerializeField] private TextMeshProUGUI pressureText;
        [SerializeField] private TextMeshProUGUI proximityText;
        [SerializeField] private TextMeshProUGUI humidityText;
        [SerializeField] private TextMeshProUGUI ambientTemperatureText;
        [SerializeField] private TextMeshProUGUI stepCounterText;

        private void Update()
        {
            var data = GameManager.CurrentSensorData;
            if (data == null)
                return;

            UpdateUI(accelerometerText, data.AccelerometerData, "Acceleration");
            UpdateUI(gyroscopeText, data.GyroscopeData, "Gyro");
            UpdateUI(gravityText, data.GravityData, "Gravity");
            UpdateUI(attitudeText, data.AttitudeData, "Attitude");
            UpdateUI(linearAccelerationText, data.LinearAcceleration, "Linear Acceleration");
            UpdateUI(magneticFieldText, data.MagneticField, "Magnetic Field");
            UpdateUI(lightLevelText, data.LightLevel, "Light Level");
            UpdateUI(pressureText, data.Pressure, "Pressure");
            UpdateUI(proximityText, data.Proximity, "Proximity");
            UpdateUI(humidityText, data.Humidity, "Humidity");
            UpdateUI(ambientTemperatureText, data.AmbientTemperature, "Ambient Temp");
            UpdateUI(stepCounterText, data.StepCounter, "Step Counter");
        }
    }
}