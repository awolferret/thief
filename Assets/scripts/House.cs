using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public Alarm alarm = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        alarm.StartSiren();
        alarm.IncreaseVolume();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        alarm.DecreaseVolume();
    }
}