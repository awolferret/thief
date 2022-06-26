using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _volumeScale = 0.01f;
    private Coroutine _coroutine;

    public void StartSiren()
    {
        _audio.Play();
    }

    public void IncreaseVolume()
    {
        float _target = 1f;
        _coroutine = StartCoroutine(ChangingVolume(_target));
    }

    public void DecreaseVolume()
    {
        float _target = 0f;
        StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(ChangingVolume(_target));
    }

    private void Start()
    {
        _audio.volume = 0f;
    }

    private IEnumerator ChangingVolume(float _target)
    {
        float waitTime = 0.05f;
        var waitType = new WaitForSeconds(waitTime);

        while (_audio.volume != _target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
            yield return waitType;
        }
    }
}