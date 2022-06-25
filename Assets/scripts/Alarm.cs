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

    public void StartSiren()
    {
        _audio.Play();
    }

    public void IncreaseVolume()
    {
        _target = 1f;
        StopCoroutine(DecreasingVolume());
        StartCoroutine(IncreasingVolume());
    }

    public void DecreaseVoume()
    {
        _target = 0f;
        StopCoroutine(IncreasingVolume());
        StartCoroutine(DecreasingVolume());
    }

    private IEnumerator IncreasingVolume()
    {
        while (_audio.volume != _target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
            yield return new WaitForSeconds(0.05f);
        }
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