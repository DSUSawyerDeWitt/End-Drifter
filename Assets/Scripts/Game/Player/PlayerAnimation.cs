using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Joystick movementJoystick;

    [SerializeField]
    private Animator animator;

    private float Anim;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(movementJoystick.Direction.x) == 0 && Mathf.Abs(movementJoystick.Direction.y) == 0)
        { //Idle Animation
            Anim = 0f;
            animator.SetFloat("MoveX", Anim);
        }
        if ((Mathf.Abs(movementJoystick.Direction.x) > .1 && Mathf.Abs(movementJoystick.Direction.x) < .55) ||
            (Mathf.Abs(movementJoystick.Direction.y) > .1 && Mathf.Abs(movementJoystick.Direction.y) < .55))
        { //Walking Animation
            Anim = 0.3f;
            animator.SetFloat("MoveX", Anim);
        }
        if (Mathf.Abs(movementJoystick.Direction.x) > .55)//|| Mathf.Abs(movementJoystick.Direction.y) > .55)
        { //you can add if you want the running animation up and down.
            Anim = 0.6f;
            animator.SetFloat("MoveX", Anim);
        }
    }
    private void FixedUpdate()
    {
        if (movementJoystick.Direction.x < 0) //moving left
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (movementJoystick.Direction.x >= 0) //moving right
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
