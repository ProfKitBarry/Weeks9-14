using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    public Vector2 clickPos;
    public Vector2 moveTowards;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(movePlayer());
    }
    public void OnPoint(InputAction.CallbackContext context)
    {
        clickPos = context.ReadValue<Vector2>();
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        float clicked = context.ReadValue<float>();
        if (clicked > 0.01f)
        {
            moveTowards = clickPos;
        }
    }
    /*IEnumerator movePlayer()
    {
        while ((Vector2)transform.position != moveTowards)
        {
            move
            yield return null;
        }
   }*/

}

