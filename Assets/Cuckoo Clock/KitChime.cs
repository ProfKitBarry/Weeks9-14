using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitChime : MonoBehaviour
{
    public KitClock clock;

    private void Start()
    {
        clock.OnTheHour.AddListener(Chime); //make sure that the function has an argument when using addlistening (in this case it's int hour)
    }

    public void Chime(int hour)
    {
        Debug.Log("Chiming "+hour+" o'clock!");
    }

    public void ChimeWithoutArgument()
    {
        Debug.Log("Chiming!");
    }
}
