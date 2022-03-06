﻿using System.Collections;
using UnityEngine;

public class DeviceLocation : MonoBehaviour
{
    private static DeviceLocation _instance;
    private static bool _enabled;

    private void Awake()
    {
        _instance = this;
    }

    public static void Enable(float desiredAccuracyInMeters, float updateDistanceInMeters, float timeoutInSeconds)
    {
        _instance.StartCoroutine(InitialisationCoroutine(desiredAccuracyInMeters, updateDistanceInMeters, timeoutInSeconds));
    }

    public static LocationInfo GetLocationData()
    {
        return !_enabled ? new LocationInfo() : Input.location.lastData;
    }

    private static IEnumerator InitialisationCoroutine(float desiredAccuracyInMeters, float updateDistanceInMeters, float timeoutInSeconds)
    {
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.FineLocation))
        {
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.FineLocation);
        }

        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Fine location is not enabled! Waiting...");
            yield return new WaitUntil(() => Input.location.isEnabledByUser);
        }
        Debug.Log("Fine location enabled!");

        Input.location.Start(desiredAccuracyInMeters, updateDistanceInMeters);

        while (Input.location.status == LocationServiceStatus.Initializing && timeoutInSeconds > 0)
        {
            Debug.Log($"Waiting for location service to start... {timeoutInSeconds}");
            yield return new WaitForSecondsRealtime(1);
            timeoutInSeconds--;
        }

        if (Input.location.status != LocationServiceStatus.Running)
        {
            Debug.LogError($"Unable to start location service. Current status is - {Input.location.status}");
            yield break;
        }

        Debug.Log("Location service running");
        _enabled = true;
    }
}