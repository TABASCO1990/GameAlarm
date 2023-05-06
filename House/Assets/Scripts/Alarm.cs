using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;

    private float _targetVolumeAlarm;
    private float _minVolumeAlarm = 0f;
    private float _maxVolumeAlarm = 1.0f;
    private float _durationAlarm = 0.5f;

    private void Awake()
    {
        _alarm.volume = _minVolumeAlarm;
    }

    public void Play()
    {
        _targetVolumeAlarm = _maxVolumeAlarm;
        _alarm.Play();
        StartCoroutine(VolumeSound());
    }

    public void Stop()
    {
        _targetVolumeAlarm = _minVolumeAlarm;

        if (_alarm.volume == _maxVolumeAlarm)
        {
            StartCoroutine(VolumeSound());
        }
    }

    private IEnumerator VolumeSound()
    {
        while (_alarm.volume != _targetVolumeAlarm)
        {
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, _targetVolumeAlarm, _durationAlarm * Time.deltaTime);

            if (_alarm.volume == _minVolumeAlarm)
            {
                _alarm.Stop();
                yield break;
            }

            yield return null;
        }
    }
}
