using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{

    public float speed = 5;
    public Vector2 movement;

    public AudioSource AttackSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //use with a stick
        //transform.position += (Vector3)movement * speed * Time.deltaTime;

        //use with the mouse position
        transform.position = movement;
    }

    public void OnMove(InputAction.CallbackContext context) //"On" is a keyword for player events
    {
        movement = context.ReadValue<Vector2>(); //we want it to read a vector2 so thats why we wrote it like that (it'll give an error otherwise)
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack! " + context.phase);

        if (context.performed == true)
        {
            AttackSFX.Play();
        }
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //The same as Mouse.current.position.ReadValue()
       movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());

    }
}
