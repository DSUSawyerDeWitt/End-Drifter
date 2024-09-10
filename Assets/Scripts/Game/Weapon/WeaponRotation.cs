using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{

    public Joystick movementJoystick;

    public float angle;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movementJoystick.Direction.x != 0)
        {
            angle = Mathf.Atan2(movementJoystick.Direction.y, movementJoystick.Direction.x) * Mathf.Rad2Deg;

        }
        if (movementJoystick.Direction.x < 0) //moving left
        {
            transform.localScale = new Vector2(1, -1);
            transform.rotation = Quaternion.Euler(0, 0, angle);

        }
        if (movementJoystick.Direction.x > 0) //moving right
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
            transform.localScale = new Vector2(1, 1);
        }
    }
}
