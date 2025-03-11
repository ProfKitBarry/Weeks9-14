using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventsDemo : MonoBehaviour
{
    //public Image bunger;    //use UnityEngine.UI image
    //you can store it as an image and use getcomponent to get the transform and stuff
    public RectTransform burger;    //use this to get the rect transform of the ui element

    void Start()
    {
        
    }

    void Update()
    {
        
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
