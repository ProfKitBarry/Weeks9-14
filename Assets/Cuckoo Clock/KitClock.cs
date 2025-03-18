using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform hourHand, minuteHand;

    public float timeAnHourTakes = 5;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;   //variable that holds a reference to a function

    Coroutine clockIsRunning;
    IEnumerator doOneHour;

    void Start()
    {
        clockIsRunning = StartCoroutine(MoveClock());
    }

    void Update()
    {
    }

    private IEnumerator MoveClock()
    {
        while (true)
        {
            doOneHour = MoveClockHandsOneHour();
            yield return StartCoroutine(doOneHour);

            //yield return doOneHour=StartCoroutine(MoveClockHandsOneHour); if doOneHour is a coroutine type
        }
    }

    private IEnumerator MoveClockHandsOneHour()
    {
        t = 0;
        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            minuteHand.Rotate(0, 0, -(360 / timeAnHourTakes) * Time.deltaTime);
            hourHand.Rotate(0, 0, -(30 / timeAnHourTakes) * Time.deltaTime);
            yield return null;
        }
        hour++;
        if (hour == 13)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
    }

    public void StopClock()
    {
        if (clockIsRunning != null)
        {
            StopCoroutine(clockIsRunning);
        }
        if (doOneHour != null)
        {
            StopCoroutine(doOneHour);
        }
    }
}
