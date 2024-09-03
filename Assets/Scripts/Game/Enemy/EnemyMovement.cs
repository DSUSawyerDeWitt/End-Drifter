using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    //public PlayerMovement Direction;
    [SerializeField]
    private float speed;

    private float distance;

    void Start()
    {
       // movementJoystick = Direction.movementJoystick;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position; //player position - enemy position.
        direction.Normalize();
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (direction.x < 0) //moving left
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (direction.x >= 0) //moving right
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
