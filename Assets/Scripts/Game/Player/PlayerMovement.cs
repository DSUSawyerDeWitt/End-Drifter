using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Joystick movementJoystick;
    private Rigidbody2D rb;


    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _joystickStrength;

    private float Anim;

    public float angle;

    Vector2 lastPosition = Vector2.zero;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {//player Movement
        if (movementJoystick.Direction.y != 0 || movementJoystick.Direction.x != 0)
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

        angle = Mathf.Atan2(movementJoystick.Direction.y, movementJoystick.Direction.x) * Mathf.Rad2Deg;
    }
}
