using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Joystick movementJoystick;
    private Rigidbody2D rb;
    private Vector2 _movementInput;

    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    [SerializeField]
    private Animator animator;


    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _joystickStrength;

    private float _movementSpeed;

    private float Anim;

    Vector2 lastPosition = Vector2.zero;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //animator.SetFloat("Speed", _movementSpeed);
        //animator.SetFloat("MoveX", Mathf.Abs(movementJoystick.Direction.x));

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
        if(Mathf.Abs(movementJoystick.Direction.x) > .55 )//|| Mathf.Abs(movementJoystick.Direction.y) > .55)
        { //you can add if you want the running animation up and down.
            Anim = 0.6f;
            animator.SetFloat("MoveX", Anim);
        }
       // if ()//greater than or equal to .55)
       // {

     //   }
    }



    // Update is called once per frame
    private void FixedUpdate()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _movementInput,
            ref _movementInputSmoothVelocity,
            0.1f);

        rb.velocity = _smoothedMovementInput * _speed;

        if (movementJoystick.Direction.y != 0)
        {
            if(movementJoystick.Direction.x > _joystickStrength || movementJoystick.Direction.y > _joystickStrength
                || movementJoystick.Direction.x < -_joystickStrength || movementJoystick.Direction.y < -_joystickStrength)
            {
                rb.velocity = new Vector2(movementJoystick.Direction.x * _speed, movementJoystick.Direction.y * _speed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        Debug.Log(movementJoystick.Direction.x);
        if(movementJoystick.Direction.x < 0) //moving left
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (movementJoystick.Direction.x >= 0) //moving right
        {
            transform.localScale = new Vector2(1, 1);
        }

        _movementSpeed = Vector2.Distance(transform.position, lastPosition) / Time.deltaTime;
        lastPosition = transform.position;



    }

    /*
    private void RotateInDirectionOfInput()
    {
        if(rb.velocity != Vector2.zero)
        {
            Quternion targetRotation = 
        }
    }
    */
    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
