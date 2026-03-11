using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEditorInternal.ReorderableList;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CodingGymWeek9Ex1 : MonoBehaviour
{
    public Vector2 movement;
    public float speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += (Vector3)movement * speed * Time.deltaTime;

        //        Make a player game object and add the PlayerInput component. Set the Default Map to Player and behaviour to
        //Invoke UnityEvents, then use the Player Move UnityEvent to call a public function in your player script that
        //uses context.action.ReadValue<Vector2>() to set a movement variable.Use this variable to move the player in
        //Update. (Don’t forget Time.deltaTime)


    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
         movement = context.action.ReadValue<Vector2>();
        
    }
}
