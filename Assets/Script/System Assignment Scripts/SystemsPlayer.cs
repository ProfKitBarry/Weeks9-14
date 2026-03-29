using UnityEngine;
using UnityEngine.InputSystem;

public class SystemsPlayer : MonoBehaviour
{
    public float speed; // speed for moving the player
    private Vector2 moveDir; // vector used to see which way the player is moving
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveThePlayer(); // moves the player every frame
    }


    // functions for controlling the player //
    public void OnMovement(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>(); //reads the value of the controller
    }
    // used to move the player based on their input
    private void moveThePlayer()
    {
        transform.position += new Vector3(moveDir.x,0,0) * speed * Time.deltaTime; // moves the player based on the direction they are moving their controller
    }
}
