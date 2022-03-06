using System.Collections.Generic;
using FSG.Android.Wifi;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Location settings")] 
    [SerializeField] private float desiredAccuracyInMeters;
    [SerializeField] private float updateDistanceInMeters;
    [SerializeField] private float locationServiceTimeout;
    
    public static DeviceSensors.SensorData CurrentSensorData;
    public static LocationInfo CurrentLocationData;
    public static List<DeviceBluetooth.BluetoothPeripheral> CurrentBluetoothData;
    public static List<BluetoothLEHardwareInterface.iBeaconData> CurrentBluetoothBeaconsData;
    public static List<AndroidWifiScanResults> CurrentWifiData;
    
    private void Awake()
    {
        Application.runInBackground = true;
    }

    private void Start()
    {
        DeviceSensors.Enable();
        DeviceLocation.Enable(desiredAccuracyInMeters, updateDistanceInMeters, locationServiceTimeout);
        DeviceBluetooth.Enable();
        DeviceWifi.Enable();
    }

    private void Update()
    {
        CurrentSensorData = DeviceSensors.GetSensorData();
        CurrentLocationData = DeviceLocation.GetLocationData();
        CurrentBluetoothData = DeviceBluetooth.GetBluetoothData();
        CurrentBluetoothBeaconsData = DeviceBluetooth.GetBluetoothBeaconsData();
        CurrentWifiData = DeviceWifi.GetWifiData();
    }
}
