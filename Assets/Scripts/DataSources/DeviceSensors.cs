using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

namespace DataSources
{
    public static class DeviceSensors
    {
        private static bool _enabled;

        private static readonly Sensor[] Sensors =
        {
            Accelerometer.current,
            Gyroscope.current,
            GravitySensor.current,
            AttitudeSensor.current,
            LinearAccelerationSensor.current,
            MagneticFieldSensor.current,
            LightSensor.current,
            PressureSensor.current,
            ProximitySensor.current,
            HumiditySensor.current,
            AmbientTemperatureSensor.current,
            StepCounter.current,
        };

        public static void Enable()
        {
            Debug.Log("Enabling sensors:");
            var enabledSensors = 0;
            foreach (var sensor in Sensors)
            {
                if (sensor == null)
                    continue;

                Debug.Log($"    - {sensor.name}");
                InputSystem.EnableDevice(sensor);
                enabledSensors++;
            }

            Debug.Log($"Enabled {enabledSensors} sensors");

            _enabled = true;
        }

        public static SensorData GetSensorData()
        {
            if (!_enabled)
                return new SensorData();

            var accelerometerData = Accelerometer.current?.acceleration.ReadValue();
            var gyroscopeData = Gyroscope.current?.angularVelocity.ReadValue();
            var gravityData = GravitySensor.current?.gravity.ReadValue();
            var attitudeData = AttitudeSensor.current?.attitude.ReadValue();
            var linearAccelerationData = LinearAccelerationSensor.current?.acceleration.ReadValue();
            var magneticFieldData = MagneticFieldSensor.current?.magneticField.ReadValue();
            var lightData = LightSensor.current?.lightLevel.ReadValue();
            var pressureData = PressureSensor.current?.atmosphericPressure.ReadValue();
            var proximityData = ProximitySensor.current?.distance.ReadValue();
            var humidityData = HumiditySensor.current?.relativeHumidity.ReadValue();
            var ambientTemperatureData = AmbientTemperatureSensor.current?.ambientTemperature.ReadValue();
            var stepCounterData = StepCounter.current?.stepCounter.ReadValue();

            return new SensorData()
            {
                accelerometerData = accelerometerData,
                gyroscopeData = gyroscopeData,
                gravityData = gravityData,
                attitudeData = attitudeData,
                linearAcceleration = linearAccelerationData,
                magneticField = magneticFieldData,
                lightLevel = lightData,
                pressure = pressureData,
                proximity = proximityData,
                humidity = humidityData,
                ambientTemperature = ambientTemperatureData,
                stepCounter = stepCounterData
            };
        }

        [System.Serializable]
        public class SensorData
        {
            public UnityCommon.Nullable<Vector3> accelerometerData;
            public UnityCommon.Nullable<Vector3> gyroscopeData;
            public UnityCommon.Nullable<Vector3> gravityData;
            public UnityCommon.Nullable<Quaternion> attitudeData;
            public UnityCommon.Nullable<Vector3> linearAcceleration;
            public UnityCommon.Nullable<Vector3> magneticField;
            public UnityCommon.Nullable<float> lightLevel;
            public UnityCommon.Nullable<float> pressure;
            public UnityCommon.Nullable<float> proximity;
            public UnityCommon.Nullable<float> humidity;
            public UnityCommon.Nullable<float> ambientTemperature;
            public UnityCommon.Nullable<float> stepCounter;
        }
    }
}