using UnityEngine;
using UnityEngine.InputSystem;

public class mousePointRevamp : MonoBehaviour
{
    public Vector2 pointTo;
    public Transform pointToObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosRemaster();
    }
    void mousePosRemaster(){
        Vector2 changeView = Camera.main.ScreenToWorldPoint(pointTo);
        transform.up = changeView;
    }
    void pointToObjectfun(){
        pointTo = pointToObject.position;
    }
    public void OnPoint(InputAction.CallbackContext context){
        pointTo = context.ReadValue<Vector2>();
    }
}