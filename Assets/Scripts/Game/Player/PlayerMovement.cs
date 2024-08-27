using System.Collections;
using System.Collections.Generic;
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
    private float _speed;

    [SerializeField]
    private float _joystickStrength;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
