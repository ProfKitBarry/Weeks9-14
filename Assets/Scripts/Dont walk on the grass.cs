using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dontwalkonthegrass : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    Animator animator;
    public float speed = 2;
    Vector3 direction;
    Vector3 mouse;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("move");
            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            direction = mouse - transform.position;
        }
        transform.position += direction * Vector3.Distance(mouse, transform.position) * speed * Time.deltaTime;

        if (Vector3.Distance(mouse, transform.position) < 0.1f)
        {
            transform.position= transform.position;
        }
    }
}
