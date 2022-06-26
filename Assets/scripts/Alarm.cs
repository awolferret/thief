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
        CheckCoroutine();
        _coroutine = StartCoroutine(ChangingVolume(_target));
    }

    public void DecreaseVolume()
    {
        float _target = 0f;
        CheckCoroutine();
        _coroutine = StartCoroutine(ChangingVolume(_target));
    }

    private void CheckCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private void Start()
    {
        _audio.volume = 0f;
    }

    private IEnumerator ChangingVolume(float target)
    {
        float waitTime = 0.05f;
        var waitType = new WaitForSeconds(waitTime);

        while (_audio.volume != target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, _volumeScale);
            yield return waitType;
        }
    }
}