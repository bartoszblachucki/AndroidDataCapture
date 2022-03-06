using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DeviceBluetooth : MonoBehaviour
{
    [SerializeField] private float scanIntervalInSeconds;

    private static DeviceBluetooth _instance;

    private static readonly List<BluetoothPeripheral> BluetoothPeripherals = new List<BluetoothPeripheral>();
    private static readonly List<BluetoothPeripheral> BluetoothPeripheralsInternal = new List<BluetoothPeripheral>();    
    
    private static readonly List<BluetoothLEHardwareInterface.iBeaconData> BluetoothBeacons = new List<BluetoothLEHardwareInterface.iBeaconData>();
    private static readonly List<BluetoothLEHardwareInterface.iBeaconData> BluetoothBeaconsInternal = new List<BluetoothLEHardwareInterface.iBeaconData>();

    private void Awake()
    {
        _instance = this;
    }

    public static void Enable()
    {
        Debug.Log("Initialising Bluetooth interface");

        BluetoothLEHardwareInterface.Initialize(true, false, () => { Debug.Log("Bluetooth initialised"); },
            (error) =>
            {
                Debug.Log("Error occured while initialising bluetooth: " + error);
                if (error.Contains("Bluetooth LE Not Enabled"))
                    BluetoothLEHardwareInterface.BluetoothEnable(true);
            });

        _instance.StartCoroutine(UpdateDataCoroutine());
    }

    public static List<BluetoothPeripheral> GetBluetoothData()
    {
        return BluetoothPeripherals;
    }
    
    public static List<BluetoothLEHardwareInterface.iBeaconData> GetBluetoothBeaconsData()
    {
        return BluetoothBeacons;
    }

    private static IEnumerator UpdateDataCoroutine()
    {
        yield return new WaitForSecondsRealtime(1);

        while (true)
        {
            BluetoothPeripherals.Clear();
            BluetoothPeripherals.AddRange(BluetoothPeripheralsInternal);
            BluetoothPeripheralsInternal.Clear();
            

            BluetoothLEHardwareInterface.ScanForPeripheralsWithServices(null, null,
                HandlePeripheralDataReceived, true);
            
            /*
            BluetoothBeacons.Clear();
            BluetoothBeacons.AddRange(BluetoothBeaconsInternal);
            BluetoothBeaconsInternal.Clear();
            BluetoothLEHardwareInterface.ScanForBeacons(null, HandleBeaconResponse);
            */

            yield return new WaitForSecondsRealtime(_instance.scanIntervalInSeconds);
        }
    }

    private static void HandleBeaconResponse(BluetoothLEHardwareInterface.iBeaconData iBeaconData)
    {
        if (BluetoothBeaconsInternal.Any(x => x.UUID == iBeaconData.UUID))
            return;
        
        BluetoothBeaconsInternal.Add(iBeaconData);
    }

    private static void HandlePeripheralDataReceived(string address, string name, int rssi, byte[] receivedBytes)
    {
        if (BluetoothPeripheralsInternal.Any(x => x.Address == address))
            return;

        var peripheral = new BluetoothPeripheral()
        {
            Address = address,
            Name = name,
            Rssi = rssi
        };

        BluetoothPeripheralsInternal.Add(peripheral);
    }

    public class BluetoothPeripheral
    {
        public string Address;
        public string Name;
        public int Rssi;

        public override string ToString()
        {
            return $"{Address} : {Name} : {Rssi}";
        }
    }
}