using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _volumeScale = 0.01f;
    private float _target;

    private void Start()
    {
        _audio.volume = 0.01f;
    }

    public void StartAlarm()
    {
        _audio.Play();
        StopCoroutine(DecreasingVolume());
    }

    public void IncreaseVolume()
    {
        _target = 1f;
        _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
    }

    public void DecreaseVoume()
    {
        _target = 0f;
        StartCoroutine(DecreasingVolume());
    }

    private IEnumerator DecreasingVolume()
    {
        while (_audio.volume != _target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
            yield return new WaitForSeconds(0.05f);
        }
    }
}