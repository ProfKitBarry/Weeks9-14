using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PressEToInteract : MonoBehaviour
{
    public SpriteRenderer sp;
    public List<Sprite> spriteChange = new List<Sprite>();
    public int spriteArrayIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        setSprite();
    }
    void setSprite(){
        sp.sprite = spriteChange[spriteArrayIndex];
    }
    public void ChangeSprite(InputAction.CallbackContext context){
        if(context.performed){
        if(spriteArrayIndex >= spriteChange.Count - 1){
            spriteArrayIndex = 0;
        }
        else{
            spriteArrayIndex += 1;
        }
        }
    }
}
