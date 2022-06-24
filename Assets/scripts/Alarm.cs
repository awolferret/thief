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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audio.Play();
        StopCoroutine(DecreaseVolume());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _target = 1f;
        _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _target = 0f;
        StartCoroutine(DecreaseVolume());
    }

    private IEnumerator DecreaseVolume()
    {
        while (_audio.volume != _target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _volumeScale);
            yield return new WaitForSeconds(0.05f);
        }
    }
}