using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public Alarm alarm = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        alarm.StartAlarm();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        alarm.IncreaseVolume();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        alarm.DecreaseVoume();
    }
}