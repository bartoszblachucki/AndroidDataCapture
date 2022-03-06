using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DataSources
{
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

        public static BluetoothData GetBluetoothData()
        {
            return new BluetoothData()
            {
                beacons = BluetoothBeacons,
                peripherals = BluetoothPeripherals
            };
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
            
                BluetoothBeacons.Clear();
                BluetoothBeacons.AddRange(BluetoothBeaconsInternal);
                BluetoothBeaconsInternal.Clear();
                BluetoothLEHardwareInterface.ScanForBeacons(null, HandleBeaconResponse);

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
            if (BluetoothPeripheralsInternal.Any(x => x.address == address))
                return;

            var peripheral = new BluetoothPeripheral()
            {
                address = address,
                name = name,
                rssi = rssi
            };

            BluetoothPeripheralsInternal.Add(peripheral);
        }

        [System.Serializable]
        public class BluetoothPeripheral
        {
            public string address;
            public string name;
            public int rssi;

            public override string ToString()
            {
                return $"{address} : {name} : {rssi}";
            }
        }

        [System.Serializable]
        public class BluetoothData
        {
            public List<BluetoothPeripheral> peripherals;
            public List<BluetoothLEHardwareInterface.iBeaconData> beacons;
        }
    }
}