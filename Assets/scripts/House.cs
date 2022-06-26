using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class House : MonoBehaviour
{
    [SerializeField] private UnityEvent _enter;
    [SerializeField] private UnityEvent _out;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _out.Invoke();
    }
}