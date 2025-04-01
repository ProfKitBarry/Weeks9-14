using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventDemo : MonoBehaviour
{
    public RectTransform banana;

    public UnityEvent TimerHasFinished;
    public float timerLength = 2;
    public float t;


    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > timerLength)
        {
            t = 0;
            TimerHasFinished.Invoke();
        }
    }

    public void IjustPushedTheButton()
    {
        Debug.Log("I just pushed the buttton");
    }

    public void IAlsoPushedTheButton()
    {
        Debug.Log("Me too!");
    }

    public void MouseIsNowInside()
    {
        Debug.Log("Mouse has entered the sprite!");
        banana.localScale = Vector3.one * 1.2f;
    }

    public void MouseIsNowOutside()
    {
        Debug.Log("Mouse has left he sprite!");
    }
}
