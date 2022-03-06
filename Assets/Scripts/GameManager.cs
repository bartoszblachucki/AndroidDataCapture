using System.Collections.Generic;
using DataSources;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Location settings")] 
    [SerializeField] private float desiredAccuracyInMeters;
    [SerializeField] private float updateDistanceInMeters;
    [SerializeField] private float locationServiceTimeout;
    
    public static DeviceSensors.SensorData CurrentSensorData;
    public static DeviceLocation.LocationData CurrentLocationData;
    public static DeviceBluetooth.BluetoothData CurrentBluetoothData;
    public static DeviceWifi.WifiData CurrentWifiData;
    
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
        CurrentWifiData = DeviceWifi.GetWifiData();
    }
}
