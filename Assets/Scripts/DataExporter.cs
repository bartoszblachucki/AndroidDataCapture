using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataSources;
using UnityEngine;

public class DataExporter : MonoBehaviour
{
    private const string OutputFileBaseName = "data_";
    private const string OutputFileFormat = "json";
    private string CurrentFileName => $"{OutputFileBaseName}{_fileNumber}.{OutputFileFormat}";
    
    private int _fileNumber;

    
    private void Awake()
    {
        _fileNumber = GetHighestDataFileNumber(Application.persistentDataPath) + 1;
    }

    private int GetHighestDataFileNumber(string directory)
    {
        var filePaths = Directory.GetFiles(directory, $"{OutputFileFormat}*", SearchOption.TopDirectoryOnly);
        if (filePaths.Length <= 0)
            return -1;

        var filenames = filePaths.Select(Path.GetFileNameWithoutExtension);
        var suffixes = filenames.Select(x => x.Replace(OutputFileFormat, ""));
        var numbers = new List<int>();
        foreach (var suffix in suffixes)
        {
            if (int.TryParse(suffix, out int number))
            {
                numbers.Add(number);
            }
        }

        numbers.Sort();
        return numbers.Last();
    }

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
        var filename = Path.Combine(Application.persistentDataPath, CurrentFileName);
        File.WriteAllText(filename, json);

        Debug.Log($"Saved data as {filename}");
        
        _fileNumber++;
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