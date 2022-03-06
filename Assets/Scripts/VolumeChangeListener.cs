using UnityEngine;
using UnityEngine.Events;

public class VolumeChangeListener : MonoBehaviour
{
    [SerializeField] private UnityEvent volumeChanged;

    private int _cachedVolume;
    private int _minVolume;
    private int _maxVolume;
    private int HalfVolume => (_minVolume + _maxVolume) / 2;

    private AndroidJavaObject _androidAudioManager;
    private AndroidJavaObject _mainActivity;

    private void Start()
    {
        _mainActivity = GetMainActivity();
        _androidAudioManager = GetAudioManager();

        _minVolume = GetMinVolume();
        _maxVolume = GetMaxVolume();
        _cachedVolume = SetVolume(HalfVolume);
    }

    private void Update()
    {
        var volume = GetVolume();

        if (volume > _cachedVolume)
        {
            volumeChanged.Invoke();
        }
        else if (volume < _cachedVolume)
        {
            volumeChanged.Invoke();
        }

        _cachedVolume = volume;

        if (volume >= _maxVolume || volume <= _minVolume)
        {
            _cachedVolume = SetVolume(HalfVolume);
        }
    }

    private AndroidJavaObject GetAudioManager()
    {
        return _mainActivity.Call<AndroidJavaObject>("getSystemService", "audio");
    }

    private static AndroidJavaObject GetMainActivity()
    {
        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        return unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    }

    private int GetVolume()
    {
        return _androidAudioManager.Call<int>("getStreamVolume", 3);
    }

    private int SetVolume(int volume)
    {
        _androidAudioManager.Call("setStreamVolume", 3, volume, 0);
        return volume;
    }

    private int GetMaxVolume()
    {
        return _androidAudioManager.Call<int>("getStreamMaxVolume", 3);
    }

    private int GetMinVolume()
    {
        return _androidAudioManager.Call<int>("getStreamMinVolume", 3);
    }
}