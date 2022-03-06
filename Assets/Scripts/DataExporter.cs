using System.Collections.Generic;
using DataSources;
using UnityEngine;
using Newtonsoft.Json;

public class DataExporter : MonoBehaviour
{
    public void ExportData()
    {
        Debug.Log("Data export started...");

        var deviceData = new DeviceData()
        {
            sensorData = GameManager.CurrentSensorData,
            locationData = GameManager.CurrentLocationData,
            bluetoothData = GameManager.CurrentBluetoothData,
            wifiData = GameManager.CurrentWifiData
        };

        var json = JsonUtility.ToJson(deviceData, true);
        Debug.Log(json);
    }

    [System.Serializable]
    private class DeviceData
    {
        public DeviceSensors.SensorData sensorData;
        public DeviceLocation.LocationData locationData;
        public DeviceBluetooth.BluetoothData bluetoothData;
        public List<BluetoothLEHardwareInterface.iBeaconData> bluetoothBeaconsData;
        public DeviceWifi.WifiData wifiData;
    }
}