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

        public static void Disable()
        {
            foreach (var sensor in Sensors)
            {
                if (sensor == null)
                    continue;

                InputSystem.DisableDevice(sensor);
            }

            _enabled = false;
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
                AccelerometerData = accelerometerData,
                GyroscopeData = gyroscopeData,
                GravityData = gravityData,
                AttitudeData = attitudeData,
                LinearAcceleration = linearAccelerationData,
                MagneticField = magneticFieldData,
                LightLevel = lightData,
                Pressure = pressureData,
                Proximity = proximityData,
                Humidity = humidityData,
                AmbientTemperature = ambientTemperatureData,
                StepCounter = stepCounterData
            };
        }

        [System.Serializable]
        public class SensorData
        {
            public UnityCommon.Nullable<Vector3> AccelerometerData;
            public UnityCommon.Nullable<Vector3> GyroscopeData;
            public UnityCommon.Nullable<Vector3> GravityData;
            public UnityCommon.Nullable<Quaternion> AttitudeData;
            public UnityCommon.Nullable<Vector3> LinearAcceleration;
            public UnityCommon.Nullable<Vector3> MagneticField;
            public UnityCommon.Nullable<float> LightLevel;
            public UnityCommon.Nullable<float> Pressure;
            public UnityCommon.Nullable<float> Proximity;
            public UnityCommon.Nullable<float> Humidity;
            public UnityCommon.Nullable<float> AmbientTemperature;
            public UnityCommon.Nullable<float> StepCounter;
        }
    }
}