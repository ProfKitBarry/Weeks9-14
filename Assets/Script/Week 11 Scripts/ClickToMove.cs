using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    public Vector2 clickPos;
    private float speed = 2;
    public LineRenderer lr;
    public Vector2 moveTowards;
    public List<Vector2> points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        points = new List<Vector2>();
        points.Add((Vector2)transform.position);

        UpdateLineRN();
        
    }

    // Update is called once per frame
    void Update()
    {
        RemoveFromList();
        StartCoroutine(movePlayer());
    }
    public void OnPoint(InputAction.CallbackContext context)
    {
        clickPos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        float clicked = context.ReadValue<float>();
        if (clicked > 0.01f)
        {
            Vector2 newPos = clickPos;
            points.Add(newPos);
            UpdateLineRN();
            
        }

    }
    void RemoveFromList()
    {
        if(points.Count > 1){
        if(Vector2.Distance(transform.position, points[1]) < 0.05f){
        points.Remove(points[1]);
        }
        }
    }
    void UpdateLineRN()
    {
        lr.positionCount = points.Count;
        for(int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }
    IEnumerator movePlayer()
    {
        if(points.Count > 1){
        while (Vector2.Distance(transform.position, points[1]) < 0.05f)
        {
            Vector2 direction = points[1] - (Vector2)transform.position;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
            yield return null;
        }
        }{}
   }

}

