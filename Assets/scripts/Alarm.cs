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
        _audio.volume = 0f;
    }

    public void StartSiren()
    {
        _audio.Play();
    }

    public void IncreaseVolume()
    {
        _target = 1f;
        StopCoroutine(ChangingVolume(_target));
        StartCoroutine(ChangingVolume(_target));
    }

    public void DecreaseVolume()
    {
        _target = 0f;
        StopCoroutine(ChangingVolume(_target));
        StartCoroutine(ChangingVolume(_target));
    }

    private IEnumerator ChangingVolume(float _target)
    {
        while (_audio.volume != _target)
        {
            Debug.Log(_target);
            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
            yield return new WaitForSeconds(0.05f);
        }
    }
}