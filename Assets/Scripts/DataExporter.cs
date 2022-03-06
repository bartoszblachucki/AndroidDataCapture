using System.Collections.Generic;
using FSG.Android.Wifi;
using UnityEngine;
using Newtonsoft.Json;

public class DataExporter : MonoBehaviour
{
    public void ExportData()
    {
        Debug.Log("Data export started...");

        var deviceData = new DeviceData()
        {
            SensorData = GameManager.CurrentSensorData,
            LocationData = GameManager.CurrentLocationData,
            BluetoothData = GameManager.CurrentBluetoothData,
            BluetoothBeaconsData = GameManager.CurrentBluetoothBeaconsData,
            WifiData = GameManager.CurrentWifiData
        };

        var json = JsonUtility.ToJson(deviceData);
        Debug.Log(json);
    }

    private class DeviceData
    {
        public DeviceSensors.SensorData SensorData;
        public LocationInfo LocationData;
        public List<DeviceBluetooth.BluetoothPeripheral> BluetoothData;
        public List<BluetoothLEHardwareInterface.iBeaconData> BluetoothBeaconsData;
        public List<AndroidWifiScanResults> WifiData;
    }
}