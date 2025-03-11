using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventsDemo : MonoBehaviour
{
    //public Image bunger;    //use UnityEngine.UI image
    //you can store it as an image and use getcomponent to get the transform and stuff
    public RectTransform burger;    //use this to get the rect transform of the ui element

    public UnityEvent OnTimerFinished; //usually it says "On[event]"
    //event is basically a variable that holds a function
    public float timerLength = 2;
    public float t;

    void Update()
    {
        t += Time.deltaTime;
        if (t > timerLength) {
            t = 0;
            OnTimerFinished.Invoke();   //run the function(s) that happen when timer is done
        }
    }

    public void IJustPushedTheButton() {
        Debug.Log("I just pushed the button!");
    }

    public void IAlsoPushedTheButton() {
        Debug.Log("Me too!");
    }

    public void MouseIsNowInside()
    {
        Debug.Log("Mouse has entered the sprite!");
        burger.localScale = Vector3.one * 1.2f;
    }

    public void MouseIsNowOutside()
    {
        Debug.Log("Mouse has exited the sprite!");
        burger.localScale = Vector3.one;
    }
}
