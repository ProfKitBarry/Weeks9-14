using System.ComponentModel;
using System.Data;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CodingGymWeek9Ex2 : MonoBehaviour
{
    public Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        Do the same for the Look UnityEvent.Use the look variable to set the rotation or direction of a gun barrel.
// If you set rotation: use the X component of the look variable and use it to increment the Z component of
//the barrel’s euler Angles
// If you set direction: use the look Vector2 to set the barrel’s transform.right(or transform.up)
//direction


    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        movement = Camera.main.ScreenToWorldPoint(context.action.ReadValue<Vector2>());
    }
}
