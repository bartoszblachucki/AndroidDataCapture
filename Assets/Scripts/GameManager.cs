using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Location settings")] 
    [SerializeField] private float desiredAccuracyInMeters;
    [SerializeField] private float updateDistanceInMeters;
    [SerializeField] private float locationServiceTimeout;
    
    public static DeviceSensors.SensorData CurrentSensorData;
    public static LocationInfo CurrentLocationData;
    //public static List<AndroidWifiScanResults> CurrentWifiData;
    //public static List<DeviceBluetooth.BluetoothPeripheral> CurrentBluetoothData;
    
    private void Awake()
    {
        Application.runInBackground = true;
    }

    private void Start()
    {
        DeviceSensors.Enable();
        DeviceLocation.Enable(desiredAccuracyInMeters, updateDistanceInMeters, locationServiceTimeout);
        //DeviceWifi.Enable();
        //DeviceBluetooth.Enable();
    }

    private void Update()
    {
        CurrentSensorData = DeviceSensors.GetSensorData();
        CurrentLocationData = DeviceLocation.GetLocationData();
        //CurrentWifiData = DeviceWifi.GetWifiData();
        //CurrentBluetoothData = DeviceBluetooth.GetBluetoothData();
    }
}
